//萬年不變的通用函數

using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Text;
using System;

public static class GolbalFunc
{
    // 從StreamingAssetss Load 圖片
    public static Sprite LoadSpriteTexture( string Spritename )
    {
        string _path = Application.dataPath + "/StreamingAssets/" + Spritename; //获取地址
        FileStream _fileStream = new FileStream( _path, FileMode.Open, FileAccess.Read ); //使用流数据读取
        byte[] _buffur = new byte[ _fileStream.Length ];
        _fileStream.Read( _buffur, 0, _buffur.Length ); //转换成字节流数据
        Texture2D _texture2d = new Texture2D( 10, 10 ); //设置宽高
        _texture2d.LoadImage( _buffur ); //将流数据转换成Texture2D
        Sprite _sprite = Sprite.Create( _texture2d, new Rect(0 , 0,  _texture2d.width,  _texture2d.height ), Vector3.zero ); //创建一个Sprite
        return _sprite;
    }

    public static string LoadText( string FileName )
    {
        string path = Application.streamingAssetsPath + "/" + FileName + ".txt";
        string txt = File.ReadAllText( path );
        return txt;
    }

    public static void WriteText( string content , string FileName )
    {
      string path = Application.streamingAssetsPath + "/" + FileName + ".txt";
      File.WriteAllText( path , content );
    }
}