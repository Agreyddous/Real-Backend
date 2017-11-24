namespace Real.Backend.Infra.Transactions
{
	public interface IUow
	{
		void ACommit();
		void Commit();
		void Rollback();
	}
}