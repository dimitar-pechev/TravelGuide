using TravelGuide.Data.Contracts;

namespace TravelGuide.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITravelGuideContext context;

        public UnitOfWork(ITravelGuideContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
