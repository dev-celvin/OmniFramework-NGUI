
public class StartUpCommand : ControllerCommand {

    public override void Execute(IMessage message) {

        //-----------------初始化管理器-----------------------
        AppFacade.Instance.AddManager<UIManager>(ManagerName.UI);
        AppFacade.Instance.AddManager<SoundManager>(ManagerName.Sound);
        AppFacade.Instance.AddManager<TimerManager>(ManagerName.Timer);
        AppFacade.Instance.AddManager<ThreadManager>(ManagerName.Thread);
        AppFacade.Instance.AddManager<ObjectPoolManager>(ManagerName.ObjectPool);
        AppFacade.Instance.AddManager<GameManager>(ManagerName.Game);
    }
}