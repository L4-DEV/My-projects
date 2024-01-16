using System.ComponentModel;

namespace SistemaDeTarefas.Enuns
{
    public enum StatusTarefa
    {
        [Description ("A fazer")]
        Open = 1,
        [Description("Em andamento")]
        Going = 2,
        [Description("Feita")]
        Closed = 3 
    }
}
