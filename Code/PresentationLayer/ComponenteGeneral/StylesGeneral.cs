using MinLab.Code.PresentationLayer.ComponenteGeneral;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MinLab.Code.PresentationLayer.ComponenteGeneral
{
    class StylesGeneral
    {
        public static void Init()
        {
            ButtonOK = new StyleUI();
            ButtonCancel = new StyleUI();
            ButtonNext = new StyleUI();
            ButtonModify = new StyleUI();
            ButtonAccept = new StyleUI();
            ButtonItem = new StyleUI();
            ButtonDefault = new StyleUI();

            ButtonOK.Size = new Size(112, 34); ButtonOK.BackGroundNormal = Color.FromArgb(0, 153, 0); ButtonOK.BackGroundLight = Color.FromArgb(0, 204, 0); ButtonOK.FontColor = Color.FromArgb(255, 255, 255); ButtonOK.FontSize = 10; ButtonOK.BordeColor = Color.FromArgb(0, 135, 0); ButtonOK.BordeSize = 1;
            ButtonCancel.Size = new Size(112, 34); ButtonCancel.BackGroundNormal = Color.FromArgb(210, 0, 0); ButtonCancel.BackGroundLight = Color.FromArgb(255, 0, 0); ButtonCancel.FontColor = Color.FromArgb(255, 255, 255); ButtonCancel.FontSize = 10; ButtonCancel.BordeColor = Color.FromArgb(192, 0, 0); ButtonCancel.BordeSize = 1;
            ButtonNext.Size = new Size(112, 34); ButtonNext.BackGroundNormal = Color.FromArgb(51, 153, 255); ButtonNext.BackGroundLight = Color.FromArgb(90, 173, 255); ButtonNext.FontColor = Color.FromArgb(255, 255, 255); ButtonNext.FontSize = 10; ButtonNext.BordeColor = Color.FromArgb(0, 112, 255); ButtonNext.BordeSize = 1;
            ButtonModify.Size = new Size(112, 34); ButtonModify.BackGroundNormal = Color.FromArgb(218, 130, 0); ButtonModify.BackGroundLight = Color.FromArgb(255, 192, 0); ButtonModify.FontColor = Color.FromArgb(255, 255, 255); ButtonModify.FontSize = 10; ButtonModify.BordeColor = Color.FromArgb(237, 125, 49); ButtonModify.BordeSize = 1;
            ButtonAccept.Size = new Size(112, 34); ButtonAccept.BackGroundNormal = Color.FromArgb(0, 153, 0); ButtonAccept.BackGroundLight = Color.FromArgb(0, 204, 0); ButtonAccept.FontColor = Color.FromArgb(255, 255, 255); ButtonAccept.FontSize = 10; ButtonAccept.BordeColor = Color.FromArgb(0, 135, 0); ButtonAccept.BordeSize = 1;
            ButtonItem.Size = new Size(138, 55); ButtonItem.BackGroundNormal = Color.FromArgb(51, 153, 255); ButtonItem.BackGroundLight = Color.FromArgb(90, 173, 255); ButtonItem.FontColor = Color.FromArgb(255, 255, 255); ButtonItem.FontSize = 10; ButtonItem.BordeColor = Color.FromArgb(0, 112, 255); ButtonItem.BordeSize = 1;
            ButtonDefault.Size = new Size(112, 34); ButtonDefault.BackGroundNormal = Color.FromArgb(51, 153, 255); ButtonDefault.BackGroundLight = Color.FromArgb(90, 173, 255); ButtonDefault.FontColor = Color.FromArgb(255, 255, 255); ButtonDefault.FontSize = 10; ButtonDefault.BordeColor = Color.FromArgb(0, 112, 255); ButtonDefault.BordeSize = 1;


            LabelTitle = new StyleUI();
            LabelSubtitle = new StyleUI();
            LabelItem = new StyleUI();

            LabelTitle.Size = new Size(500, 40); LabelTitle.FontColor = Color.FromArgb(22, 22, 22); LabelTitle.FontSize = 12;
            LabelSubtitle.Size = new Size(500, 40); LabelSubtitle.FontColor = Color.FromArgb(22, 22, 22); LabelSubtitle.FontSize = 11;
            LabelItem.Size = new Size(300, 40); LabelItem.FontColor = Color.FromArgb(22, 22, 22); LabelItem.FontSize = 10;


        }


        public static StyleUI ButtonOK { get; set; }
        public static StyleUI ButtonCancel { get; set; }
        public static StyleUI ButtonNext { get; set; }
        public static StyleUI ButtonModify { get; set; }
        public static StyleUI ButtonAccept { get; set; }
        public static StyleUI ButtonItem { get; set; }
        public static StyleUI ButtonDefault { get; set; }

        public static StyleUI LabelTitle { get; set; }
        public static StyleUI LabelSubtitle { get; set; }
        public static StyleUI LabelItem { get; set; }




    }
}
