using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Castle.Core.Internal;
using HouseholdAcountApp.View;
using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
using LibDomain.Exceptions;
using LibDomain.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HouseholdAcountAppTest
{
    [TestClass]
    public class SaveFormModelTest
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

            var modelMock = new Mock<SaveFormModel>(homeMock.Object, receiveMock.Object, typeMock.Object);
            modelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2020/01/01"));
            var testModel = modelMock.Object;

            testModel.SelectedDay.Is(Convert.ToDateTime("2020/01/01"));
            testModel.MoneyNameText.Is("");
            testModel.MoneyText.Is("");
            testModel.SelectedExpend.IsNull();
            testModel.SelectedType.IsNull();
            testModel.SelectedReceived.IsNull();

            testModel.Type.Count.Is(2);
            testModel.Receive.Count.Is(2);
            testModel.Expend.Count.Is(3);

            testModel.Type[0].TypeName.Is("食事代");
            testModel.Receive[0].ReceiveName.Is("現金");
            testModel.Expend[0].DisplayValue.Is("支出");
        }

        [TestMethod]
        public void saveTest()
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

            var modelMock = new Mock<SaveFormModel>(homeMock.Object, receiveMock.Object, typeMock.Object);
            var testModel = modelMock.Object;

            var ex = AssertEx.Throws<InputException>(() => testModel.IsCheckForm());
            ex.Message.Is("全て入力してください。");

            testModel.SelectedExpend = 1;
            ex = AssertEx.Throws<InputException>(() => testModel.IsCheckForm());
            ex.Message.Is("全て入力してください。");

            testModel.SelectedReceived = 1;
            ex = AssertEx.Throws<InputException>(() => testModel.IsCheckForm());
            ex.Message.Is("全て入力してください。");

            testModel.SelectedType = 1;
            ex = AssertEx.Throws<InputException>(() => testModel.IsCheckForm());
            ex.Message.Is("全て入力してください。");

            testModel.MoneyNameText = "買い物";
            ex = AssertEx.Throws<InputException>(() => testModel.IsCheckForm());
            ex.Message.Is("全て入力してください。");

            testModel.MoneyText = "-1";
            ex = AssertEx.Throws<InputException>(() => testModel.IsCheckForm());
            ex.Message.Is("金額は0以上を入力してください。");

            testModel.SelectedDay = Convert.ToDateTime("2020/01/01");
            testModel.MoneyText = "1000";

            homeMock.Setup(x => x.Insert(It.IsAny<HomeEntity>())).
                Callback<HomeEntity>(saveValue =>
                {
                    saveValue.MoneyName.Is("買い物");
                    saveValue.Type.TypeId.Is(1);
                    saveValue.Receive.ReceiveId.Is(1);
                    saveValue.Expend.DisplayValue.Is("支出");
                    saveValue.MoneyInt.Is(1000);
                    saveValue.Created.Is(Convert.ToDateTime("2020/01/01"));
                });

            // 保存処理テスト開始
            testModel.Save();
            homeMock.VerifyAll();
        }
    }
}
