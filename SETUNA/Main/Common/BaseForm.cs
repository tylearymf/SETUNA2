using System.Windows.Forms;

public class BaseForm : Form
{
    public static new Form ActiveForm { set; get; }


    public BaseForm()
    {
        SETUNA.Main.FormManager.RegisterForm(this);
    }

    ~BaseForm()
    {
        SETUNA.Main.FormManager.DeregisterForm(this);
    }
}
