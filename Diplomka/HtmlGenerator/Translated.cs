﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplomka.HtmlGenerator
{
    public static class TranslateGenerator
    {
        public static MvcHtmlString Translated(this HtmlHelper helper, string eng, List<string> ukr)
        {
            #region Translated
            TagBuilder Translated = new TagBuilder("div");//Whole translted form
            #region english-translted
            TagBuilder english_translate = new TagBuilder("div");//english form
            TagBuilder uk_word = new TagBuilder("p");//english words
            TagBuilder uk_img = new TagBuilder("img");//uk-image
            #endregion
            #region icon
            TagBuilder font_icon = new TagBuilder("div");//icon
            TagBuilder icon = new TagBuilder("i");//font icon
            #endregion
            #region ukraine-translate
            TagBuilder ukraine_translate = new TagBuilder("div");//ukraine form
            TagBuilder ua_words = new TagBuilder("p");
            TagBuilder ua_img = new TagBuilder("img");
            #endregion
            #endregion

            //english form
            english_translate.AddCssClass("english-translate");
            uk_word.SetInnerText(eng);
            english_translate.InnerHtml += uk_word.ToString();
            uk_img.MergeAttribute("src", "/Content/Image/Pages/UK.png");
            uk_img.MergeAttribute("width", "100%");
            uk_img.MergeAttribute("height", "100%");
            english_translate.InnerHtml += uk_img.ToString();

            //icon-form
            font_icon.AddCssClass("icon");
            icon.AddCssClass("fas fa-arrow-circle-right");
            font_icon.InnerHtml += icon.ToString();

            //ukraine form
            ukraine_translate.AddCssClass("ukraine-translate");
            foreach (var word in ukr)
            {
                TagBuilder enter = new TagBuilder("br");
                ua_words.SetInnerText(word);
                ua_words.InnerHtml += enter.ToString();
            }
            ukraine_translate.InnerHtml += ua_words.ToString();
            ua_img.MergeAttribute("src", "/Content/Image/Pages/UA.png");
            ua_img.MergeAttribute("width", "100%");
            ua_img.MergeAttribute("height", "100%");
            ukraine_translate.InnerHtml += ua_img.ToString();

            //nested to Whole Form
            Translated.AddCssClass("Translated");
            Translated.InnerHtml += english_translate;
            Translated.InnerHtml += font_icon;
            Translated.InnerHtml += ukraine_translate;

            

            return new MvcHtmlString(Translated.ToString());
        }
    }
}