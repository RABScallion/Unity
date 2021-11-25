using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
/*RABScallion 2021.11.19*/
public enum 序号类型 
{
    数字,
    英文,    
    中文,
}

public class BatchRename : MonoBehaviour
{   [ExecuteInEditMode]
    //[Header("要改名的队列")]
    //[SerializeField]
    public bool 是否自定义子集数量;
    


    [Tooltip("默认为子集总数量,勾选自定义修改子集数量后，此栏才有效")]
    public int 需要修改名称的子集数量;

    [Tooltip("不勾选此项，则直接在原有名称后加上序号")]
    public bool 是否修改子集原有名称;

    [Tooltip("不勾选修改子集原有名称后，此栏才有效")]
    public string 新的统一名称部分;

    [Tooltip("我是名称 我是名称与序号间的字符 我是序号")]
    public string 名称与序号间的字符="_";

    [Header("加序号模块")]

    [Tooltip("英文、中文最多支持99个子集改名")]
    public 序号类型 序号类型;

    
    
   

    private List<GameObject> Mono = new List<GameObject>();
    private Dictionary<int, string> 数字中文转换 = new Dictionary<int, string>();
    private Dictionary<int, string> 数字英文转换 = new Dictionary<int, string>();

    [Header("加相同后缀模块")]

    public  string 统一后缀的字符 = "00";

    [Space]
    [Header("Tips")]
    [Tooltip("把枯燥的命名时间转化为快乐的摸鱼时间的神奇脚本！")]
    public string Tips;


    [ContextMenu("开始加序号")]
    void ChangeName()
    {
        Mono.Clear();
        
        if (!是否自定义子集数量)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Mono.Add(transform.GetChild(i).gameObject);
            }
        }
        else
        {
            if (需要修改名称的子集数量<1)
            {
                throw new IndexOutOfRangeException("设置子集数需要至少大于1");               
            }
            else if (需要修改名称的子集数量>transform.childCount)
            {
                throw new IndexOutOfRangeException("设置子集数不能超过真实的子集数量");               
            }
            for (int i = 0; i < 需要修改名称的子集数量; i++)
            {
                Mono.Add(transform.GetChild(i).gameObject);
            }
        }
                
        for (int i = 0; i < Mono.Count; i++)
        {
            if (是否修改子集原有名称)
            {
                switch (序号类型)
                {
                    case 序号类型.英文:

                        if (i <= 20)
                        {

                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + 数字英文转换[i];
                        }
                        if (i % 10 == 0)
                        {
                            switch (i)
                            {
                                case 30:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Thirty ";
                                    break;
                                case 40:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Forty ";
                                    break;
                                case 50:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Fifty ";
                                    break;
                                case 60:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Sixty ";
                                    break;
                                case 70:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Seventy ";
                                    break;
                                case 80:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Eighty ";
                                    break;
                                case 90:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Ninety ";
                                    break;
                                case 100:
                                    Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "One-Hundred ";
                                    break;
                                default:
                                    break;

                            }
                        }
                        else if (i < 30)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Twenty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 40)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Thirty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 50)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Forty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 60)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Fifty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 70)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Sixty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 80)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Seventy-" + 数字英文转换[i % 10];
                        }
                        else if (i < 90)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Eighty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 100)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "Ninety " + 数字英文转换[i % 10];
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("当前英文改名只支持到100个子集");
                        }

                        break;
                    case 序号类型.数字:
                        if (i < 10)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "0" + (i).ToString();
                        }
                        else
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + (i).ToString();
                        }
                        break;
                    case 序号类型.中文:
                        if (i <= 10)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + 数字中文转换[i];
                        }
                        else if (i < 20)
                        {
                            Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + "十" + 数字中文转换[i % 10];
                        }
                        else if (i <= 99)
                        {
                            if (i % 10 == 0)
                            {
                                Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + 数字中文转换[(int)(i / 10)] + "十";
                            }
                            else
                            {
                                Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + 数字中文转换[(int)(i / 10)] + "十" + 数字中文转换[i % 10];
                            }
                        }
                        else if (i > 99)
                        {
                            throw new IndexOutOfRangeException("当前中文改名只支持到100个子集");
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (!是否修改子集原有名称)
            {
                switch (序号类型)
                {
                    case 序号类型.英文:

                        if (i <= 20)
                        {

                            Mono[i].name += 名称与序号间的字符 + 数字英文转换[i];
                        }
                        if (i % 10 == 0)
                        {
                            switch (i)
                            {
                                case 30:
                                    Mono[i].name +=  名称与序号间的字符 + "Thirty ";
                                    break;
                                case 40:
                                    Mono[i].name +=  名称与序号间的字符 + "Forty ";
                                    break;
                                case 50:
                                    Mono[i].name +=  名称与序号间的字符 + "Fifty ";
                                    break;
                                case 60:
                                    Mono[i].name +=  名称与序号间的字符 + "Sixty ";
                                    break;
                                case 70:
                                    Mono[i].name +=  名称与序号间的字符 + "Seventy ";
                                    break;
                                case 80:
                                    Mono[i].name +=  名称与序号间的字符 + "Eighty ";
                                    break;
                                case 90:
                                    Mono[i].name += 名称与序号间的字符 + "Ninety ";
                                    break;
                                case 100:
                                    Mono[i].name +=  名称与序号间的字符 + "One-Hundred ";
                                    break;
                                default:
                                    break;

                            }
                        }
                        else if (i < 30)
                        {
                            Mono[i].name += 名称与序号间的字符 + "Twenty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 40)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "Thirty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 50)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "Forty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 60)
                        {
                            Mono[i].name += 名称与序号间的字符 + "Fifty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 70)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "Sixty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 80)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "Seventy-" + 数字英文转换[i % 10];
                        }
                        else if (i < 90)
                        {
                            Mono[i].name += 名称与序号间的字符 + "Eighty-" + 数字英文转换[i % 10];
                        }
                        else if (i < 100)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "Ninety " + 数字英文转换[i % 10];
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("当前英文改名只支持到100个子集");
                        }

                        break;
                    case 序号类型.数字:
                        if (i < 10)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "0" + (i).ToString();
                        }
                        else
                        {
                            Mono[i].name +=  名称与序号间的字符 + (i).ToString();
                        }
                        break;
                    case 序号类型.中文:
                        if (i <= 10)
                        {
                            Mono[i].name +=  名称与序号间的字符 + 数字中文转换[i];
                        }
                        else if (i < 20)
                        {
                            Mono[i].name +=  名称与序号间的字符 + "十" + 数字中文转换[i % 10];
                        }
                        else if (i <= 99)
                        {
                            if (i % 10 == 0)
                            {
                                Mono[i].name +=  名称与序号间的字符 + 数字中文转换[(int)(i / 10)] + "十";
                            }
                            else
                            {
                                Mono[i].name +=  名称与序号间的字符 + 数字中文转换[(int)(i / 10)] + "十" + 数字中文转换[i % 10];
                            }
                        }
                        else if (i > 99)
                        {
                            throw new IndexOutOfRangeException("当前中文改名只支持到100个子集");
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }
        Debug.Log("修改 " + "<color=#ff8400>" + transform.name + "</color>" + "的 " + "<color=#ff8400>"+ Mono.Count+ "</color>" + " 个子集名称成功");
    }
    [ContextMenu("开始加相同后缀")]
    void ChangeSameName()
    {
        Mono.Clear();
        if (!是否自定义子集数量)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Mono.Add(transform.GetChild(i).gameObject);
            }

        }
        else
        {
            if (需要修改名称的子集数量 < 1)
            {
                throw new IndexOutOfRangeException("设置子集数需要至少大于1");
            }
            else if (需要修改名称的子集数量 > transform.childCount)
            {
                throw new IndexOutOfRangeException("设置子集数不能超过真实的子集数量");
            }
            for (int i = 0; i < 需要修改名称的子集数量; i++)
            {
                Mono.Add(transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < Mono.Count; i++)
        {
            if (是否修改子集原有名称)
            {
                Mono[i].name = 新的统一名称部分 + 名称与序号间的字符 + 统一后缀的字符;
            }
            else if (!是否修改子集原有名称)
            {
                Mono[i].name += 名称与序号间的字符 + 统一后缀的字符;
            }
            

        }
        Debug.Log("修改 " + "<color=#ff8400>" + transform.name + "</color>" + "的 " + "<color=#ff8400>" + Mono.Count + "</color>" + " 个子集名称成功");

    }
    void Reset()
    {
        Mono.Clear();
        数字中文转换[0] = "零";
        数字中文转换[1] = "一";
        数字中文转换[2] = "二"; 
        数字中文转换[3] = "三"; 
        数字中文转换[4] = "四"; 
        数字中文转换[5] = "五";
        数字中文转换[6] = "六";
        数字中文转换[7] = "七";
        数字中文转换[8] = "八";
        数字中文转换[9] = "九";
        数字中文转换[10] = "十";
        
        数字英文转换[0] = "Zero";
        数字英文转换[1] = "One";
        数字英文转换[2] = "Two";
        数字英文转换[3] = "Three";
        数字英文转换[4] = "Four";
        数字英文转换[5] = "Five";
        数字英文转换[6] = "Six";
        数字英文转换[7] = "Seven";
        数字英文转换[8] = "Eight";
        数字英文转换[9] = "Nine";
        数字英文转换[10] = "Ten";
        数字英文转换[11] = "Eleven";
        数字英文转换[12] = "Twelve";
        数字英文转换[13] = "Thirteeen";
        数字英文转换[14] = "Fourteen";
        数字英文转换[15] = "Fifteen";
        数字英文转换[16] = "Sixteen";
        数字英文转换[17] = "Seventeen";
        数字英文转换[18] = "Eighteen";
        数字英文转换[19] = "Nineteen";
        数字英文转换[20] = "Twenty";
        是否修改子集原有名称 = false;
        新的统一名称部分 = transform.name + "_Child";
        Tips = "改名完成后，可移除脚本";
        需要修改名称的子集数量 = transform.childCount;
        统一后缀的字符 = "00";
    }


}
