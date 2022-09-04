using ChainSpy.Intefaces;

namespace ChainSpy;

public partial class App : Application
{
	public App(IDatabaseContext dbContext)
	{
		InitializeComponent();

		MainPage = new AppShell();

		Task.Run(async () =>  {
			await dbContext.SetupDatabase();

        } );

        

	}
}
