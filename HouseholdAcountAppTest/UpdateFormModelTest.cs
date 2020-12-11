using System;
using System.Collections.Generic;
using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
using LibDomain.Exceptions;
using LibDomain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HouseholdAcountAppTest
{
    [TestClass]
    public class UpdateFormModelTest
    {
        [TestMethod]
        public void formTest()
        {
            var typeMock = new Mock<ITypeRepository>();
            var receiveMock = new Mock<IReceiveRepository>();
            var homeMock = new Mock<IHomeRepository>();

            var typeList = new List<TypeEntity>();
            typeList.Add(new TypeEntity(1, "食事代"));
            typeList.Add(new TypeEntity(2, "日用品"));

            var receiveList = new List<ReceiveEntity>();
            receiveList.Add(new ReceiveEntity(1, "現金"));
            receiveList.Add(new ReceiveEntity(2, "クレジットカード"));

            typeMock.Setup(x => x.selectAll()).Returns(typeList);
            receiveMock.Setup(x => x.selectAll()).Returns(receiveList);

            var modelMock = new Mock<UpdateFormModel>(homeMock.Object, receiveMock.Object, typeMock.Object);
            modelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2020/01/01"));
            var testModel = modelMock.Object;

            testModel.SelectedDay.Is(Convert.ToDateTime("2020/01/01"));
            testModel.MoneyNameText.Is("");
            testModel.MoneyText.Is("");
            testModel.SelectedExpend.IsNull();
            testModel.SelectedType.IsNull();
            testModel.SelectedReceived.IsNull();
        }

        [TestMethod]
        public void datasetTest()
        {
            var typeMock = new Mock<ITypeRepository>();
            var receiveMock = new Mock<IReceiveRepository>();
            var homeMock = new Mock<IHomeRepository>();

            var typeList = new List<TypeEntity>();
            typeList.Add(new TypeEntity(1, "食事代"));
            typeList.Add(new TypeEntity(2, "日用品"));

            var receiveList = new List<ReceiveEntity>();
            receiveList.Add(new ReceiveEntity(1, "現金"));
            receiveList.Add(new ReceiveEntity(2, "クレジットカード"));

            var homeEntity = new HomeEntity(1, "食事", 1, "食事代", 1, "現金", 1, 1000, Convert.ToDateTime("2020/11/01"));

            homeMock.Setup(x => x.select_byId(1)).Returns(homeEntity);
            typeMock.Setup(x => x.selectAll()).Returns(typeList);
            receiveMock.Setup(x => x.selectAll()).Returns(receiveList);

            var modelMock = new Mock<UpdateFormModel>(homeMock.Object, receiveMock.Object, typeMock.Object);
            modelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2020/01/01"));
            var testModel = modelMock.Object;

            var ex = AssertEx.Throws<InputException>(() => testModel.SetHomeEntityId(0));
            ex.Message.Is("選択したデータが取得できませんでした。");

            testModel.SetHomeEntityId(1);
            testModel.SelectedDay.Is(Convert.ToDateTime("2020/11/01"));
            testModel.MoneyNameText.Is("食事");
            testModel.MoneyText.Is("1000");
            testModel.SelectedType.Is(1);
            testModel.SelectedReceived.Is(1);
            testModel.SelectedExpend.Is(1);

            homeMock.Setup(x => x.Update(It.IsAny<HomeEntity>())).
                 Callback<HomeEntity>(saveValue =>
                 {
                     saveValue.MoneyName.Is("食事");
                     saveValue.Type.TypeId.Is(1);
                     saveValue.Receive.ReceiveId.Is(1);
                     saveValue.Expend.DisplayValue.Is("支出");
                     saveValue.MoneyInt.Is(1000);
                     saveValue.Created.Is(Convert.ToDateTime("2020/11/01"));
                 });

            // 保存処理テスト開始
            testModel.Update();
            homeMock.VerifyAll();
        }
    }
}
