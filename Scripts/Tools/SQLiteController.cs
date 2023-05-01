using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;

public class SQLiteController : MonoBehaviour
{

    public SQLiteConnection Connection;

    // Start is called before the first frame update
    void Start()
    {
        Connection = new SQLiteConnection( Application.streamingAssetsPath+ "/TestDatabase.db",SQLiteOpenFlags.ReadWrite| SQLiteOpenFlags.Create );
        Connection.CreateTable< TestTable >();
    }

    public class TestTable
    {
        [ PrimaryKey, AutoIncrement ] //设置主键 自动增长
        public int    Id     { get; set; } //Id作为主键
        public string Name   { get; set; }
        public int    Age    { get; set; }
        public float  Height { get; set; }
        public float  Weight { get; set; }

        public override string ToString()
        {
            return string.Format( "[Person: Id={0}, Name={1},  Age={2}, Height={3}]，Weight={4}]", Id, Name, Age, Height, Weight );
        }
    }

    void InsertData()
    {
        var p = new TestTable
        {
            Id = 1,
            Name = "Chinar",
            Age = 999,
            Height = 180.5f,
            Weight = 140.3f
        };
        Connection.Insert( p );
    }


    void InsertDatas()
    {
        Connection.InsertAll( new[]
        {
            new TestTable
            {
                Name = "小明",
                Age = 12,
                Height = 130.3f,
                Weight = 100.2f
            },
            new TestTable
            {
                Name   = "老皮",
                Age    = 12,
                Height = 133f,
                Weight = 96.2f
            },
        });
    }

    void DeleteDataByName()
    {
        var data = Connection.Table< TestTable >().Where( _ => _.Name == "Chinar" ).FirstOrDefault();
        Connection.Delete( data );
    }

    void DeleteDataByPrimaryKey()
    {
        //基於ID刪除資料
        Connection.Delete<TestTable>( 1 );
    }


    void SelectData ()
    {
        var datas = Connection.Table< TestTable >().Where( _ => _.Age == 12 );
        foreach (var v in datas)
        {
            Debug.Log(v.Name);
        }
    }
}