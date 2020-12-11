using LibDomain.Exceptions;
using LibDomain.Repository;
using LibDomain.ValueObjects;
using LibInfrastructure.SQLIte;
using System;
using NLog;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibDomain.Entity;

namespace HouseholdAcountApp.ViewModel
{
    public class IndexViewModel : ViewModelBase
    {
        IHomeRepository _home;
        IReceiveRepository _receive;
        ITypeRepository _type;
        IExpendRepository _expend;

        private Logger Test_logger = LogManager.GetCurrentClassLogger();

        public IndexViewModel() 
            : this( new HomeSQLite(), new ReceiveSQLite(), new TypeSQLite(), new ExpendSQLite() ){ 
            // TODO コンストラクタ
        }

        public IndexViewModel(
            IHomeRepository home, 
            IReceiveRepository receive,
            ITypeRepository type,
            IExpendRepository expend) {
            // TODO コンストラクタ
            _home = home;
            _receive = receive;
            _type = type;
            _expend = expend;
        }

        public void Search() {
            // TODO 検索(日付と支出/収入セレクト)
            string today = DomainHelper.createDay(SelectedYear, SelectedMonth, SelectedDay);
            int selectEx = Convert.ToInt32(SelectedExpend);

            change_viewTable(_home.select_byDay(today, selectEx));
       }

        public void SearchToTest()
        {
            // TODO 検索(テスト用)
            change_viewTable(_home.SelectAll());
        }

        public void CopyObject(DataGridViewSelectedRowCollection rows) 
        {
            // TODO 複製処理
            foreach (DataGridViewRow row in rows)
            {
                // 名前からデータベースのID取得
                TypeEntity typ = _type.Select_byName(Convert.ToString(row.Cells[2].Value));
                ReceiveEntity rec = _receive.select_byName(Convert.ToString(row.Cells[3].Value));
                ExpendEntity exp = _expend.select_byName(Convert.ToString(row.Cells[4].Value));

                // 1つでも該当しないIDがあったら飛ばす
                if ( typ == null || rec == null || exp == null ) {
                    continue;
                }

                // オブジェクト生成
                HomeEntity entity = new HomeEntity(
                    0,
                    Convert.ToString(row.Cells[1].Value),
                    typ.TypeId, 
                    rec.ReceiveId,
                    exp.ExpendId,
                    Convert.ToInt32(row.Cells[5].Value),
                    GetDateTime()
                    );

                // 追加処理
                _home.Insert(entity);
            }
        }

        public void Delete(DataGridViewSelectedRowCollection rows)
        {
            // 削除処理
            List<int> moneyIdList = new List<int>();
            foreach (DataGridViewRow row in rows)
            {
                moneyIdList.Add(Convert.ToInt32(row.Cells[0].Value));
            }
            _home.Delete(moneyIdList);
        }

        public void UpdateView() {
            // ビューの更新
            if (IsCheckForm_returnBool())
            {
                Search();
            }
            else
            {
                SearchToTest();
            }
        }

        public void ClearSelectCombobox() {
            // TODO コンボボックスの初期化
            SelectedYear = null;
            SelectedMonth = null;
            SelectedDay = null;
            SelectedExpend = null;
        }

        public void IsCheckForm()
        {
            // TODO セレクト中身チェック
            string ms = "適したメッセージではありませんでした。";
            IsQuestion.IsNullString(SelectedYear, ms);
            IsQuestion.IsNullString(SelectedMonth, ms);
            IsQuestion.IsNullString(SelectedDay, ms);
            IsQuestion.IsNullString(SelectedExpend, ms);
        }

        public bool IsCheckForm_returnBool()
        {
            // TODO セレクト中身チェック
            return (IsQuestion.IsNullString_returnBool(SelectedYear) &&
                    IsQuestion.IsNullString_returnBool(SelectedMonth) &&
                    IsQuestion.IsNullString_returnBool(SelectedDay) &&
                    IsQuestion.IsNullString_returnBool(SelectedExpend)) ;
        }

        public void IsCheckZero(int count)
        {
            // TODO 件数チェック
            IsQuestion.IsZero(count, "選択されていません。");
        }

        public void IsCheckCount(int data, int count)
        {
            // TODO 件数の一致
            IsQuestion.IsNotCount(data, count, "データが正しく選択されていません。");
        }

        public bool IsCheckDialog(string word)
        {
            // TODO デリートチェック
            DialogResult result = MessageBox.Show(word, "確認",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Exclamation,
                   MessageBoxDefaultButton.Button2);
            return (result == DialogResult.Yes);
        }

        public List<MoneyEntity> setBalancePage(bool isLeft) {
            // TODO 貸借対照表のデータ確保

            // 支出/収入番号チェック
            bool checkExpend = IsQuestion.IsNullString_returnBool(SelectedExpend);
            int expendNum = 0;
            if ( checkExpend ) {
                int checkEx = Convert.ToInt32(SelectedExpend);
                if ((checkEx == 1 || checkEx == 2)) {
                    expendNum = checkEx;
                }
            }

            IReadOnlyList<TypeEntity> typeList = _type.selectAll();
            IReadOnlyList<ReceiveEntity> recList = _receive.selectAll();
            List<MoneyEntity> moneyList = new List<MoneyEntity>();
            string today = "";
            string edtoday = "";
            if (IsQuestion.IsNullString_returnBool(SelectedYear) &&
                    IsQuestion.IsNullString_returnBool(SelectedMonth) &&
                    IsQuestion.IsNullString_returnBool(SelectedDay))
            {
                // ●●年●●月●●日
                today = DomainHelper.createDay(SelectedYear, SelectedMonth, SelectedDay);
            } else if (IsQuestion.IsNullString_returnBool(SelectedYear) &&
                        IsQuestion.IsNullString_returnBool(SelectedMonth)) {
                // ●●年●●月1日～●●年●●月31日
                DayObject month = new DayObject(Convert.ToString(SelectedMonth));
                today = DomainHelper.createDay(SelectedYear, month.InputDay, "01");
                edtoday = DomainHelper.createDay(SelectedYear, month.InputDay, "31");
            }
            else if (IsQuestion.IsNullString_returnBool(SelectedYear)){
                // ●●年1月1日～●●年12月31日
                today = DomainHelper.createDay(SelectedYear, "01", "01");
                edtoday = DomainHelper.createDay(SelectedYear, "12", "31");
            }

            // ジャンル
            if (isLeft)
            {
                foreach (TypeEntity entity in typeList)
                {
                    MoneyEntity money = null;
                    if (today == "")
                    {
                        money = (expendNum == 0 ?
                                _home.select_MoneySum_byTypeId(entity.TypeId) :
                                _home.select_MoneySum_byTypeId(entity.TypeId, expendNum));
                    }
                    else
                    {
                        if (edtoday == "")
                        {
                            money = (expendNum == 0 ?
                                _home.select_MoneySum_byTypeId(entity.TypeId, Convert.ToDateTime(today)) :
                                _home.select_MoneySum_byTypeId(entity.TypeId, expendNum, Convert.ToDateTime(today)));
                        }
                        else
                        {
                            edtoday = DomainHelper.CheckDate(edtoday);
                            money = (expendNum == 0 ?
                               _home.select_MoneySum_byTypeId(entity.TypeId, Convert.ToDateTime(today), Convert.ToDateTime(edtoday)) :
                               _home.select_MoneySum_byTypeId(entity.TypeId, expendNum, Convert.ToDateTime(today), Convert.ToDateTime(edtoday)));
                        }
                    }
                    if (money != null) { moneyList.Add(money); }
                }
            }
            else {
                // 支払い
                foreach (ReceiveEntity entity in recList)
                {
                    MoneyEntity money = null;
                    if (today == "")
                    {
                        money = (expendNum == 0 ?
                                    _home.select_MoneySum_byReceiveId(entity.ReceiveId) :
                                    _home.select_MoneySum_byReceiveId(entity.ReceiveId, expendNum));
                    }
                    else
                    {
                        if (edtoday == "")
                        {
                            money = (expendNum == 0 ?
                                    _home.select_MoneySum_byReceiveId(entity.ReceiveId, Convert.ToDateTime(today)) :
                                    _home.select_MoneySum_byReceiveId(entity.ReceiveId, expendNum, Convert.ToDateTime(today)));
                        }
                        else
                        {
                            edtoday = DomainHelper.CheckDate(edtoday);
                            money = (expendNum == 0 ?
                                    _home.select_MoneySum_byReceiveId(entity.ReceiveId, Convert.ToDateTime(today), Convert.ToDateTime(edtoday)) :
                                    _home.select_MoneySum_byReceiveId(entity.ReceiveId, expendNum, Convert.ToDateTime(today), Convert.ToDateTime(edtoday)));
                        }
                    }
                    if (money != null) {    moneyList.Add(money); }
                }
            }
            return moneyList;
        }

        private void change_viewTable(IReadOnlyList<HomeEntity> list)
        {
            // TODO 表示リストの詰め替え
            HomeEntityModel.Clear();
            foreach (var entity in list)
            {
                HomeEntityModel.Add(new HomeEntityModel(entity));
            }
        }

        public BindingList<HomeEntityModel>
            HomeEntityModel{ get; set; } = new BindingList<HomeEntityModel>();

        public object SelectedYear { get; set; }

        public BindingList<CreatedDay> Years { get; set; }
            = new BindingList<CreatedDay>(CreatedDay.ToList(1));

        public object SelectedMonth { get; set; }

        public BindingList<CreatedDay> Months { get; set; }
            = new BindingList<CreatedDay>(CreatedDay.ToList(2));

        public object SelectedDay { get; set; }

        public BindingList<CreatedDay> Days { get; set; }
            = new BindingList<CreatedDay>(CreatedDay.ToList(3));

        public object SelectedExpend { get; set; }

        public BindingList<ExpendObject> Expend { get; set; }
            = new BindingList<ExpendObject>(ExpendObject.ToList());

    }
}
