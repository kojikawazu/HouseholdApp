using System;
using System.Collections.Generic;
using System.ComponentModel;
using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
using LibDomain.Exceptions;
using LibDomain.Repository;
using LibDomain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HouseholdAcountAppTest
{
    [TestClass]
    public class HomeEntityModelTest
    {
        [TestMethod]
        public void entityTest()
        {
            DateTime timer = DateTime.Now;
            var homeObject = new HomeEntity(1, "食事", 1, "食事代", 1, "現金", 1, 1000, timer);
            Assert.AreEqual(1, homeObject.MoneyId);
            Assert.AreEqual("食事", homeObject.MoneyName);
            Assert.AreEqual("食事代", homeObject.Type.TypeName);
            Assert.AreEqual("現金", homeObject.Receive.ReceiveName);
            Assert.AreEqual("支出", homeObject.Expend.DisplayValue);
            Assert.AreEqual(1000, homeObject.MoneyInt);
            Assert.AreEqual(timer, homeObject.Created);

            var receiveObject = new ReceiveEntity(1, "現金");
            Assert.AreEqual(1, receiveObject.ReceiveId);
            Assert.AreEqual("現金", receiveObject.ReceiveName);

            var typeObject = new TypeEntity(1, "食事代");
            Assert.AreEqual(1, typeObject.TypeId);
            Assert.AreEqual("食事代", typeObject.TypeName);

            var expandObject = new ExpendEntity(1, "支出");
            Assert.AreEqual(1, expandObject.ExpendId);
            Assert.AreEqual("支出", expandObject.ExpendName);

        }

        [TestMethod]
        public void entityListTest()
        {
            IList<CreatedDay> createYearList = CreatedDay.ToList(1);
            Assert.AreEqual(31, createYearList.Count);
            IList<CreatedDay> createMonthList = CreatedDay.ToList(2);
            Assert.AreEqual(12, createMonthList.Count);
            IList<CreatedDay> createDayList = CreatedDay.ToList(3);
            Assert.AreEqual(31, createDayList.Count);
            IList<CreatedDay> createEmptyList = CreatedDay.ToList(4);
            Assert.AreEqual(0, createEmptyList.Count);
        }

        [TestMethod]
        public void databaseTest()
        {
            var homeMock = new Mock<IHomeRepository>();
            var homeList = new List<HomeEntity>();

            var receiveMock = new Mock<IReceiveRepository>();
            var receiveList = new List<ReceiveEntity>();

            var typeMock = new Mock<ITypeRepository>();
            var typeList = new List<TypeEntity>();

            var expendMock = new Mock<IExpendRepository>();

            // 支出
            homeList.Add(new HomeEntity(1, "食事", 1, "食事代", 1, "現金", 1, 1000, Convert.ToDateTime("2020/11/01")));
            // その他
            homeList.Add(new HomeEntity(2, "日用品", 2, "日用品", 1, "クレジットカード", 3, 1000, Convert.ToDateTime("2020/11/02")));

            // 方法テーブル
            receiveList.Add(new ReceiveEntity(1, "現金"));
            receiveList.Add(new ReceiveEntity(2, "クレジットカード"));

            homeMock.Setup(x => x.SelectAll()).Returns(homeList);
            receiveMock.Setup(x => x.selectAll()).Returns(receiveList);
            typeMock.Setup(x => x.selectAll()).Returns(typeList);

            var indexViewModelMock = new Mock<IndexViewModel>(homeMock.Object, receiveMock.Object, typeMock.Object, expendMock.Object );
            var indexViewModel = indexViewModelMock.Object;

            // モデルチェック
            indexViewModel.SearchToTest();
            indexViewModel.HomeEntityModel.Count.Is(2);

            indexViewModel.HomeEntityModel[0].MoneyId.Is("1");
            indexViewModel.HomeEntityModel[0].MoneyName.Is("食事");
            indexViewModel.HomeEntityModel[0].TypeId.Is("食事代");
            indexViewModel.HomeEntityModel[0].ReceiveId.Is("現金");
            indexViewModel.HomeEntityModel[0].expendId.Is("支出");
            indexViewModel.HomeEntityModel[0].MoneyInt.Is("1000");
            indexViewModel.HomeEntityModel[0].Created.Is("2020/11/01");

            indexViewModel.HomeEntityModel[1].MoneyId.Is("2");
            indexViewModel.HomeEntityModel[1].MoneyName.Is("日用品");
            indexViewModel.HomeEntityModel[1].TypeId.Is("日用品");
            indexViewModel.HomeEntityModel[1].ReceiveId.Is("クレジットカード");
            indexViewModel.HomeEntityModel[1].expendId.Is("その他");
            indexViewModel.HomeEntityModel[1].MoneyInt.Is("1000");
            indexViewModel.HomeEntityModel[1].Created.Is("2020/11/02");

        }

        [TestMethod]
        public void searchTest()
        {
            var homeMock = new Mock<IHomeRepository>();
            var homeList = new List<HomeEntity>();

            var receiveMock = new Mock<IReceiveRepository>();
            var receiveList = new List<ReceiveEntity>();

            var typeMock = new Mock<ITypeRepository>();
            var typeList = new List<TypeEntity>();

            var expendMock = new Mock<IExpendRepository>();

            receiveMock.Setup(x => x.selectAll()).Returns(receiveList);
            typeMock.Setup(x => x.selectAll()).Returns(typeList);

            var indexViewModelMock = new Mock<IndexViewModel>(homeMock.Object, receiveMock.Object, typeMock.Object, expendMock.Object);
            var indexViewModel = indexViewModelMock.Object;

            // 初期チェック
            indexViewModel.SelectedYear.IsNull("");
            indexViewModel.SelectedMonth.IsNull("");
            indexViewModel.SelectedDay.IsNull("");
            indexViewModel.SelectedExpend.IsNull("");

            // フォームチェック
            var ex = AssertEx.Throws<InputException>(() => indexViewModel.IsCheckForm());
            ex.Message.Is("適したメッセージではありませんでした。");

            indexViewModel.SelectedYear = "2020";
            ex = AssertEx.Throws<InputException>(() => indexViewModel.IsCheckForm());
            ex.Message.Is("適したメッセージではありませんでした。");

            indexViewModel.SelectedMonth = "11";
            ex = AssertEx.Throws<InputException>(() => indexViewModel.IsCheckForm());
            ex.Message.Is("適したメッセージではありませんでした。");

            indexViewModel.SelectedDay = "1";
            ex = AssertEx.Throws<InputException>(() => indexViewModel.IsCheckForm());
            ex.Message.Is("適したメッセージではありませんでした。");

            Assert.AreEqual(false, indexViewModel.IsCheckForm_returnBool());
            indexViewModel.SelectedExpend = 1;
            Assert.AreEqual(true, indexViewModel.IsCheckForm_returnBool());

            // 検索チェック
            homeList.Clear();
            homeList.Add(new HomeEntity(1, "飲み会", 1, "食事代", 1, "現金", 1, 2000, Convert.ToDateTime("2020/11/01")));
            homeMock.Setup(x => x.select_byDay("2020-11-01", 1)).Returns(homeList);

            indexViewModel.Search();
            indexViewModel.HomeEntityModel.Count.Is(1);

            indexViewModel.HomeEntityModel[0].MoneyId.Is("1");
            indexViewModel.HomeEntityModel[0].MoneyName.Is("飲み会");
            indexViewModel.HomeEntityModel[0].TypeId.Is("食事代");
            indexViewModel.HomeEntityModel[0].ReceiveId.Is("現金");
            indexViewModel.HomeEntityModel[0].expendId.Is("支出");
            indexViewModel.HomeEntityModel[0].MoneyInt.Is("2000");
            indexViewModel.HomeEntityModel[0].Created.Is("2020/11/01");
        }

        [TestMethod]
        public void deleteTest()
        {
            var homeMock = new Mock<IHomeRepository>();
            var homeList = new List<HomeEntity>();

            var receiveMock = new Mock<IReceiveRepository>();
            var receiveList = new List<ReceiveEntity>();

            var typeMock = new Mock<ITypeRepository>();
            var typeList = new List<TypeEntity>();

            var expendMock = new Mock<IExpendRepository>();

            receiveMock.Setup(x => x.selectAll()).Returns(receiveList);
            typeMock.Setup(x => x.selectAll()).Returns(typeList);

            var indexViewModelMock = new Mock<IndexViewModel>(homeMock.Object, receiveMock.Object, typeMock.Object, expendMock.Object);
            var indexViewModel = indexViewModelMock.Object;

            Assert.AreEqual(false, indexViewModel.IsCheckForm_returnBool());
            indexViewModel.SelectedYear = "2020";
            indexViewModel.SelectedMonth = "11";
            indexViewModel.SelectedDay = "1";
            indexViewModel.SelectedExpend = 1;
            Assert.AreEqual(true, indexViewModel.IsCheckForm_returnBool());

            var ex = AssertEx.Throws<InputException>(() => indexViewModel.IsCheckZero(0));
            ex.Message.Is("選択されていません。");

            ex = AssertEx.Throws<InputException>(() => indexViewModel.IsCheckCount(1, 2));
            ex.Message.Is("データが正しく選択されていません。"); 
        }

        [TestMethod]
        public void balanceTest()
        {
            var homeMock = new Mock<IHomeRepository>();
            var homeList = new List<HomeEntity>();

            var receiveMock = new Mock<IReceiveRepository>();
            var receiveList = new List<ReceiveEntity>();

            var typeMock = new Mock<ITypeRepository>();
            var typeList = new List<TypeEntity>();

            var expendMock = new Mock<IExpendRepository>();

            typeList.Add(new TypeEntity(1, "食事代"));
            typeList.Add(new TypeEntity(2, "日用品"));

            receiveList.Add(new ReceiveEntity(1, "現金"));
            receiveList.Add(new ReceiveEntity(2, "クレジットカード"));

            homeList.Add(new HomeEntity(1, "飲み会", 1, "食事代", 1, "現金", 1, 2000, Convert.ToDateTime("2020/11/01")));
            MoneyEntity moneyL = new MoneyEntity("食事", 1000);
            MoneyEntity moneyR = new MoneyEntity("現金", 1000);
            homeMock.Setup(x => x.SelectAll()).Returns(homeList);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1)).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1)).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, Convert.ToDateTime("2020/11/01"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, Convert.ToDateTime("2020/11/01"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 0, Convert.ToDateTime("2020/11/01"), Convert.ToDateTime("2020/11/30"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 0, Convert.ToDateTime("2020/11/01"), Convert.ToDateTime("2020/11/30"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 1, Convert.ToDateTime("2020/11/01"), Convert.ToDateTime("2020/11/30"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 1, Convert.ToDateTime("2020/11/01"), Convert.ToDateTime("2020/11/30"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 0)).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 0)).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 1)).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 1)).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 0, Convert.ToDateTime("2020/11/01"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 0, Convert.ToDateTime("2020/11/01"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 1, Convert.ToDateTime("2020/11/01"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 1, Convert.ToDateTime("2020/11/01"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, Convert.ToDateTime("2020/11/01"), Convert.ToDateTime("2020/11/30"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, Convert.ToDateTime("2020/11/01"), Convert.ToDateTime("2020/11/30"))).Returns(moneyR);

            receiveMock.Setup(x => x.selectAll()).Returns(receiveList);
            typeMock.Setup(x => x.selectAll()).Returns(typeList);

            var indexViewModelMock = new Mock<IndexViewModel>(homeMock.Object, receiveMock.Object, typeMock.Object, expendMock.Object);
            var indexViewModel = indexViewModelMock.Object;

            indexViewModel.SelectedYear.IsNull("");
            indexViewModel.SelectedMonth.IsNull("");
            indexViewModel.SelectedDay.IsNull("");
            indexViewModel.SelectedExpend.IsNull("");
            List<MoneyEntity> list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);
            
            list.Clear();
            indexViewModel.SelectedExpend = 0;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            list.Clear();
            indexViewModel.SelectedExpend = 1;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            list.Clear();
            indexViewModel.SelectedYear = "2020";
            indexViewModel.SelectedMonth = "11";
            indexViewModel.SelectedDay = "1";
            indexViewModel.SelectedExpend = 0;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            list.Clear();
            indexViewModel.SelectedExpend = 1;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            list.Clear();
            indexViewModel.SelectedExpend = 0;
            indexViewModel.SelectedYear = "2020";
            indexViewModel.SelectedMonth = "11";
            indexViewModel.SelectedDay = null;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            list.Clear();
            indexViewModel.SelectedExpend = 1;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 0, Convert.ToDateTime("2020/01/01"), Convert.ToDateTime("2020/12/31"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 0, Convert.ToDateTime("2020/01/01"), Convert.ToDateTime("2020/12/31"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, 1, Convert.ToDateTime("2020/01/01"), Convert.ToDateTime("2020/12/31"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, 1, Convert.ToDateTime("2020/01/01"), Convert.ToDateTime("2020/12/31"))).Returns(moneyR);
            homeMock.Setup(x => x.select_MoneySum_byTypeId(1, Convert.ToDateTime("2020/01/01"), Convert.ToDateTime("2020/12/31"))).Returns(moneyL);
            homeMock.Setup(x => x.select_MoneySum_byReceiveId(1, Convert.ToDateTime("2020/12/31"), Convert.ToDateTime("2020/12/31"))).Returns(moneyR);
            
            list.Clear();
            indexViewModel.SelectedExpend = 0;
            indexViewModel.SelectedYear = "2020";
            indexViewModel.SelectedMonth = null;
            indexViewModel.SelectedDay = null;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);

            list.Clear();
            indexViewModel.SelectedExpend = 1;
            list = indexViewModel.setBalancePage(true);
            list.Count.Is(1);

            list.Clear();
            list = indexViewModel.setBalancePage(false);
            list.Count.Is(1);
        }
    }
}
