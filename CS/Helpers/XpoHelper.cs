using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using System.Configuration;
using System.Reflection;

public static class XpoHelper {
    private const string ConnectionStringName = "ConnStr";

    static XpoHelper() {
        UpdateDatabase();
    }

    public static Session GetNewSession() {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork() {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object lockObject = new object();

    static volatile IDataLayer fDataLayer;
    static IDataLayer DataLayer {
        get {
            if (fDataLayer == null) {
                lock (lockObject) {
                    if (fDataLayer == null) {
                        fDataLayer = GetDataLayer();
                    }
                }
            }
            return fDataLayer;
        }
    }

    private static IDataLayer GetDataLayer() {
        XpoDefault.Session = null;
        XPDictionary dict = new ReflectionDictionary();
        dict.GetDataStoreSchema(Assembly.GetExecutingAssembly());
        return new ThreadSafeDataLayer(dict, XpoDefault.GetConnectionProvider(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString,
            AutoCreateOption.None));
    }

    static void UpdateDatabase() {
        using (IDataLayer dal = XpoDefault.GetDataLayer(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString,
            AutoCreateOption.DatabaseAndSchema)) {
                using (Session session = new Session(dal)) {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    session.UpdateSchema(asm);
                    session.CreateObjectTypeRecords(asm);
                }
        }
    }
}
