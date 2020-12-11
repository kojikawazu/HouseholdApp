using LibDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Repository
{
    public interface IHomeRepository
    { 

        IReadOnlyList<HomeEntity> SelectAll();

        IReadOnlyList<HomeEntity> select_byDay(string day, int isExpend);

        HomeEntity select_byId(int id);

        MoneyEntity select_MoneySum_byTypeId(int typeId);

        MoneyEntity select_MoneySum_byReceiveId(int receiveId);

        MoneyEntity select_MoneySum_byTypeId(int typeId, int expendId);

        MoneyEntity select_MoneySum_byReceiveId(int receiveId,int expendId);

        MoneyEntity select_MoneySum_byTypeId(int typeId, DateTime created);

        MoneyEntity select_MoneySum_byReceiveId(int receiveId, DateTime created);

        MoneyEntity select_MoneySum_byTypeId(int typeId, int expendId, DateTime created);

        MoneyEntity select_MoneySum_byReceiveId(int receiveId, int expendId, DateTime created);

        MoneyEntity select_MoneySum_byTypeId(int typeId, DateTime stCreated, DateTime edCreated);

        MoneyEntity select_MoneySum_byReceiveId(int receiveId, DateTime stCreated, DateTime edCreated);

        MoneyEntity select_MoneySum_byTypeId(int typeId, int expendId, DateTime stCreated, DateTime edCreated);

        MoneyEntity select_MoneySum_byReceiveId(int receiveId, int expendId, DateTime stCreated, DateTime edCreated);

        void Insert(HomeEntity entity);

        void Update(HomeEntity entity);

        void Delete(List<int> IdList);
    }
}
