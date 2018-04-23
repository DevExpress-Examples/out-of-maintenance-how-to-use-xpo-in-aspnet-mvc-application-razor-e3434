using DevExpress.Xpo;

public abstract class BaseViewModel<T> {
    int id = -1;
    public int ID {
        get { return id; }
        set { id = value; }
    }

    public abstract void GetData(T model);
}