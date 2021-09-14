using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonpuzzlelights : MonoBehaviour
{
    public int buttonIndex = -1;

    private bool[] combo1 = new bool[5];//2 комбинаций для каждой кнопки
    private bool[] combo2 = new bool[5];

    public void buttonFunc()//Меняем значение ламп и меняем комбинацию кнопки
    {
        switch (buttonIndex)
        {
            case 1:
                if (GlobalValues.buttonState1)
                    changerCombo1();
                else
                    changerCombo2();
                GlobalValues.buttonState1 = !GlobalValues.buttonState1;
                break;
            case 2:
                if (GlobalValues.buttonState2)
                    changerCombo1();
                else
                    changerCombo2();
                GlobalValues.buttonState2 = !GlobalValues.buttonState2;
                break;
            case 3:
                if (GlobalValues.buttonState3)
                    changerCombo1();
                else
                    changerCombo2();
                GlobalValues.buttonState3 = !GlobalValues.buttonState3;
                break;
            case 4:
                if (GlobalValues.buttonState4)
                    changerCombo1();
                else
                    changerCombo2();
                GlobalValues.buttonState4 = !GlobalValues.buttonState4;
                break;
            default:
                break;
        }
    }
    void Start() //Парсим комбинации для кнопок на основе индекса кнопки
    {
        switch (buttonIndex)
        {
            case 1:
                combo1[0] = true;
                combo1[1] = false;
                combo1[2] = true;
                combo1[3] = false;
                combo1[4] = false;

                combo2[0] = false;
                combo2[1] = false;
                combo2[2] = false;
                combo2[3] = true;
                combo2[4] = true;
                break;
            case 2:
                combo1[0] = false;
                combo1[1] = true;
                combo1[2] = true;
                combo1[3] = false;
                combo1[4] = true;

                combo2[0] = false;
                combo2[1] = false;
                combo2[2] = false;
                combo2[3] = false;
                combo2[4] = true;
                break;
            case 3:
                combo1[0] = true;
                combo1[1] = false;
                combo1[2] = true;
                combo1[3] = true;
                combo1[4] = false;

                combo2[0] = true;
                combo2[1] = false;
                combo2[2] = false;
                combo2[3] = false;
                combo2[4] = false;
                break;
            case 4:
                combo1[0] = true;
                combo1[1] = true;
                combo1[2] = false;
                combo1[3] = false;
                combo1[4] = false;

                combo2[0] = true;
                combo2[1] = false;
                combo2[2] = true;
                combo2[3] = false;
                combo2[4] = true;
                break;
            default:
                combo1[0] = false;
                combo1[1] = false;
                combo1[2] = false;
                combo1[3] = false;
                combo1[4] = false;

                combo2[0] = false;
                combo2[1] = false;
                combo2[2] = false;
                combo2[3] = false;
                combo2[4] = false;
                break;
        }
    }

    void puzzleBoolSwitch(int pos)//переворачиватель булов
    {
            lightpuzzlemanager.lightsState[pos] = !lightpuzzlemanager.lightsState[pos];
    }

    void changerCombo1()//переворачивание значений булов лампочек на основе комбо
    {
        if (combo1[0])
            puzzleBoolSwitch(0);
        if (combo1[1])
            puzzleBoolSwitch(1);
        if (combo1[2])
            puzzleBoolSwitch(2);
        if (combo1[3])
            puzzleBoolSwitch(3);
        if (combo1[4])
            puzzleBoolSwitch(4);
    }

    void changerCombo2()
    {
        if (combo2[0])
            puzzleBoolSwitch(0);
        if (combo2[1])
            puzzleBoolSwitch(1);
        if (combo2[2])
            puzzleBoolSwitch(2);
        if (combo2[3])
            puzzleBoolSwitch(3);
        if (combo2[4])
            puzzleBoolSwitch(4);
    }

}
