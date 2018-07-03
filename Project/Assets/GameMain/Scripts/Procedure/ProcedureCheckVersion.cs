using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

namespace FYProject
{
    /// <summary>
    /// 版本检测流程 TODO
    /// </summary>
    public class ProcedureCheckVersion : ProcedureBase
    {
        private bool m_ResourceInitComplete = false;

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_ResourceInitComplete)
            {
                return;
            }

            ChangeState<ProcedurePreload>(procedureOwner);
        }

    }

}