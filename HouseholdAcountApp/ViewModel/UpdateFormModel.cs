using LibDomain.Entity;
using LibDomain.Exceptions;
using LibDomain.Repository;
using LibDomain.ValueObjects;
using LibInfrastructure.SQLIte;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAcountApp.ViewModel
{
    public class UpdateFormModel : ViewModelBase
    {
        IHomeRepository _home;
        IReceiveRepository _receive;
        ITypeRepository _type;

        private Logger Test_logger = LogManager.GetCurrentClassLogger();

        public UpdateFormModel()
            : this(new HomeSQLite(), new ReceiveSQLite(), new TypeSQLite())
        {
            // TODO コンストラクタ
        }

        public UpdateFormModel(
            IHomeRepository home,
            IReceiveRepository receive,
            ITypeRepository type)
        {
            // TODO コンストラクタ
            _home = home;
            _receive = receive;
            _type = type;

            Init();
        }

        private void Init()
        {
            // TODO 初期化
            SelectedDay = GetDateTime();
            MoneyNameText = string.Empty;
            MoneyText = string.Empty;

            foreach (var entity in _type.selectAll())
            {
                Type.Add(new TypeEntity(entity.TypeId, entity.TypeName));
            }
            foreach (var entity in _receive.selectAll())
            {
                Receive.Add(new ReceiveEntity(entity.ReceiveId, entity.ReceiveName));
            }
        }

        public void SetHomeEntityId(int id) {
            // TODO IDによる値のフォームの設定
            HomeEntity entity = _home.select_byId(id);
            if (entity == null) {
                throw new InputException("選択したデータが取得できませんでした。");
            }

            // 設定
            SelectedId = entity.MoneyId;

            SelectedDay = entity.Created;
            MoneyNameText = entity.MoneyName;
            MoneyText = Convert.ToString(entity.MoneyInt);
            SelectedType = entity.Type.TypeId;
            SelectedReceived = entity.Receive.ReceiveId;
            SelectedExpend = entity.Expend.Value;
        }

        public void IsCheckForm() {
            // TODO 入力チェック
            string ms = "全て入力してください。";
            IsQuestion.IsNull(SelectedExpend, ms);
            IsQuestion.IsNull(SelectedType, ms);
            IsQuestion.IsNull(SelectedReceived, ms);
            IsQuestion.IsNullString(MoneyNameText, ms);
            IsQuestion.IsNullString(MoneyText, ms);
            IsQuestion.IsMinus(Convert.ToInt32(MoneyText), "金額は0以上を入力してください。");
        }

        public void Update() {
            // TODO 更新処理
            int moneyValue = Convert.ToInt32(MoneyText);
            var moneyObject = new HomeEntity(
                SelectedId, MoneyNameText, Convert.ToInt32(SelectedType), Convert.ToInt32(SelectedReceived),
                Convert.ToInt32(SelectedExpend), moneyValue, SelectedDay);

            _home.Update(moneyObject);
        }

        private int SelectedId { get; set; }

        //支出 / 収入のコンボボックス
        public object SelectedExpend { get; set; }

        public BindingList<ExpendObject> Expend { get; set; }
            = new BindingList<ExpendObject>(ExpendObject.ToList());

        // 日付の？？？？
        public DateTime SelectedDay { get; set; }

        // 名前のテキストボックス
        public string MoneyNameText { get; set; }

        // ジャンルのコンボボックス
        public object SelectedType { get; set; }

        public BindingList<TypeEntity> Type { get; set; }
            = new BindingList<TypeEntity>();

        // 支払方法のコンボボックス
        public object SelectedReceived { get; set; }

        public BindingList<ReceiveEntity> Receive { get; set; }
            = new BindingList<ReceiveEntity>();

        // 金額のテキストボックス
        public object MoneyText { get; set; }
    }
}
