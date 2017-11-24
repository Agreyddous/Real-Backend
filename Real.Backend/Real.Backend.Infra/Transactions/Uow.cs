using Real.Backend.Infra.Context;

namespace Real.Backend.Infra.Transactions
{
	public class Uow : IUow
	{
		private readonly RealContext _context;

		public Uow(RealContext context) => _context = context;

		public void ACommit() => _context.SaveChangesAsync();
		public void Commit() => _context.SaveChanges();
		public void Rollback() { }
	}
}