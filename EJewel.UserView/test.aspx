<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="EJewel.UserView.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
  <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link href="/assets/controls/messidialog/messi.css" rel="stylesheet" type="text/css" />
    <script src="/assets/controls/messidialog/messi.js" type="text/javascript"></script>
  <script type="text/javascript">

      $(document).ready(function (e) {
          //
          $('#simple').on('click', function () {
              new Messi('This is a message with Messi.');
          });
          //
          $("#carat-slider").slider(
	  {
	      range: true,
	      min: 0,
	      max: 100,
	      step: 1,
	      values: [0, 100],
	      slide: function (event, ui) {
	          //get point
	          $(this).find(".ui-slider-range").css({ "left": ui.values[0] + "%", "width": (ui.values[1] - ui.values[0]) + "%" });
	      }
	  });
          //Color Slider
          $("#color-slider").slider({
              range: true,
              min: 0,
              max: 100,
              step: 14.30,
              values: [0, 100],
              slide: function (event, ui) {
                  //get point
                  $(this).find(".ui-slider-range").css({ "left": ui.values[0] + "%", "width": (ui.values[1] - ui.values[0]) + "%" });
              }
          });
      });
  </script>

  <style type="text/css">
      .chooses-block.chooses-shape {
    width: 220px;
}
#shape {
    padding: 0;
    margin: 0 0 0 -6px;
    list-style: none;
    font-size: 0;
    line-height: 0px;
}
#shape li {
    float: left;
    width: 22px;
    height: 24px;
    text-align: center;
    margin: 0;
    list-style: none;
    display: block;
    overflow: hidden;
    border: none;
    cursor: pointer;
}
#shape li.selected {
    background: url(http://pics.bluenile.com/assets/chrome/builder/sprite_icon-diamond-search3.gif) no-repeat 0 -1738px;
}
#shape li span {
    display: block;
    vertical-align: middle;
    cursor: pointer;
}
#shape li .sprite_byo_shape_icon {
    width: 22px;
    height: 22px;
    vertical-align: middle;
    margin: 1px 0 0 0;
}
#shape li input,  #shape li label {
    display: none;
}
.tip {
    display: none;
    z-index: 1500;
    position: absolute;
    margin-top: 8px;
    width: 65px;
}
.tip-top {
    background: url(http://pics.bluenile.com/assets/chrome/edu/edu_popup_uparrow.gif) no-repeat top center;
    height: 5px;
    overflow: hidden;
    padding: 0;
    margin-bottom: -1px;
    position: relative;
    z-index: 1;
    width: 100%;
}
.tip-text {
    color: #555;
    background-color: #FFFFFF;
    border: 1px solid #111111;
    padding: 4px;
    text-align: center;
    font-size: 0.9em;
    height: 58px;
}
.sprite_byo_shape_icon {
    background: url(http://pics.bluenile.com/assets/chrome/builder/sprite_icon_shapes_22x22.gif) no-repeat top left;
}
.sprite-but_byo_shape_AS_OFF {
    background-position: 0 0;
}
.sprite-but_byo_shape_AS_ON {
    background-position: 0 -72px;
}
.sprite-but_byo_shape_CU_OFF {
    background-position: 0 -144px;
}
.sprite-but_byo_shape_CU_ON {
    background-position: 0 -216px;
}
.sprite-but_byo_shape_EC_OFF {
    background-position: 0 -288px;
}
.sprite-but_byo_shape_EC_ON {
    background-position: 0 -360px;
}
.sprite-but_byo_shape_HS_OFF {
    background-position: 0 -432px;
}
.sprite-but_byo_shape_HS_ON {
    background-position: 0 -504px;
}
.sprite-but_byo_shape_MQ_OFF {
    background-position: 0 -576px;
}
.sprite-but_byo_shape_MQ_ON {
    background-position: 0 -648px;
}
.sprite-but_byo_shape_OV_OFF {
    background-position: 0 -720px;
}
.sprite-but_byo_shape_OV_ON {
    background-position: 0 -792px;
}
.sprite-but_byo_shape_PS_OFF {
    background-position: 0 -864px;
}
.sprite-but_byo_shape_PS_ON {
    background-position: 0 -936px;
}
.sprite-but_byo_shape_PR_OFF {
    background-position: 0 -1008px;
}
.sprite-but_byo_shape_PR_ON {
    background-position: 0 -1080px;
}
.sprite-but_byo_shape_RA_OFF {
    background-position: 0 -1152px;
}
.sprite-but_byo_shape_RA_ON {
    background-position: 0 -1224px;
}
.sprite-but_byo_shape_RD_OFF {
    background-position: 0 -1296px;
}
.sprite-but_byo_shape_RD_ON {
    background-position: 0 -1368px;
}
.chooses-block.chooses-carat {
    width: 216px;
    margin-left: 15px;
}
.chooses-block.chooses-carat .choose-box .choose-selected {
    margin: 0 27px 0 18px;
}
.chooses-block.chooses-color .divisions UL LI {
    margin-left: 13px;
    width: 18px;
}
.chooses-block.chooses-color .divisions UL LI.last {
    margin-right: 0px;
    width: 10px;
}
.chooses-block.chooses-color {
    width: 216px;
}
.chooses-block.chooses-color .choose-box .choose-selected {
    margin: 0 82px 0 25px;
}
.chooses-block.chooses-color .divisions UL LI,  .chooses-block.chooses-cut .divisions UL LI {
    text-align: left;
}
.chooses-block.chooses-cut .divisions {
    overflow: visible;
}
.chooses-block.chooses-cut .divisions ul {
    width: 232px;
}
.chooses-block.chooses-cut .divisions UL LI {
    margin-left: 3px;
    width: 40px;
}
.chooses-block.chooses-cut .divisions UL LI.first {
    width: 35px;
}
.chooses-block.chooses-cut .divisions UL LI.last {
    width: 60px;
}
.chooses-block.chooses-cut {
    width: 216px !important;
}
.chooses-block.chooses-cut .choose-box .choose-selected {
    margin: 0 97px 0 0;
}
.chooses-block.chooses-clarity {
    _margin-left: 3px;
}
.chooses-block.chooses-clarity .divisions UL LI {
    margin-left: 3px;
    width: 24px;
}
.chooses-block.chooses-clarity .divisions UL LI.vvs2 {
    margin-left: -2px;
    width: 32px;
}
.chooses-block.chooses-clarity .divisions UL LI.vvs1 {
    margin-left: 0px;
    width: 32px;
}
.chooses-block.chooses-clarity .divisions UL LI.if,  .chooses-block.chooses-clarity .divisions UL LI.fl {
    width: 18px;
}
.chooses-block.chooses-clarity {
    width: 216px;
}
.chooses-block.chooses-clarity .choose-box .choose-selected {
    margin: 0 70px 0 45px;
}
      .ui-slider .ui-slider-range {
    _position: relative;
}
.ui-slider .tickMark {
    _margin-top: -19px;
    _position: absolute;
}
.ui-slider.small-slider .tickMark {
    _margin-top: -9px;
    _position: absolute;
}
.reset-search {
    position: absolute;
    right: 10px;
    top: 4px;
}
.ds-reset-link {
    font-size: 0.7em;
}
.ds-reset-link.larger {
    font-size: 1.2em;
}
.chooses-table .title,  .chooses-depth .title,  .chooses-pricePerCarat .title,  .fluorescence .title {
    margin-bottom: 5px;
}
.chooses-lxw {
    width: 152px;
}
#adv-polish.chooses-block .title,  #adv-symmetry.chooses-block .title {
    margin-bottom: 2px;
    margin-left: 0px;
}
#adv-date.chooses-block {
    margin-left: 15px;
    margin-right: 3px;
    _margin-left: 10px;
}
#adv-lxw.chooses-block {
    margin-left: 14px;
    margin-right: 3px;
    _margin-left: 10px;
}
.adv-date ul,  .adv-date ul li button {
    font-family: Verdana,  Tahoma,  Arial,  sans-serif;
    font-size: 9px;
    font-weight: bold;
    margin: 0px 0px 0px 10px;
}
.adv-date ul li {
    border: 1px solid #DFE0E1;
    line-height: 1;
    list-style: none;
    padding: 3px 6px;
}
.adv-date ul li a {
    text-decoration: none;
}
.adv-date ul li.selected,  .adv-date ul li.selected a {
    background-color: #006699;
    color: #FFFFFF;
}
.adv-date ul li.unselected,  .adv-date ul li.unselected a {
    background-color: #FFFFFF;
    color: #006699;
}
.adv-date LI A input {
    display: none;
}
.slider-container {
    margin: 0px 0px 0px 10px;
    display: block;
    padding: 0px 5px 5px 5px;
    float: left;
}
.slider-container h3 {
    margin: 0px 0px 5px -5px;
    padding: 0px 0px 0px 11px;
    font-size: 10px;
    text-transform: uppercase;
    color: #006699;
    background: url(http://pics.bluenile.com/assets/chrome/builder/sprite_icon-diamond-search4.gif) no-repeat 0px 2px;
}
.ui-slider {
    width: 216px;
    position: relative;
    background: url(http://pics.bluenile.com/assets/chrome/builder/byo_sliderBgd.gif) no-repeat;
    height: 20px;
}
.ui-slider .ui-slider-range {
    border: 0 none;
    display: block;
    font-size: 0.7em;
    position: absolute;
    z-index: 1;
    height: 26px;
    width: 100%;
    margin-top: -2px;
}
.ui-slider .ui-slider-handle {
    cursor: pointer;
    position: absolute;
    z-index: 4;
    outline: none;
    margin-left: -6px;
    margin-top: -2px;
}
.ui-slider .ui-slider-handle img {
    border: 0px;
}
.ui-slider .right-handle {
    left: 100%;
}
.slider-container a:focus {
    outline: none;
}
.max-handle.init {
    right: 0;
}
.tick {
    z-index: 3;
    height: 17px;
    position: absolute;
    margin-top: 1px;
    border-left: 1px solid #3C8EBA;
    width: 2px;
}
.tick.bg {
    z-index: 1;
    border-left: 1px solid #DBDBDB;
}
.slider-container input {
    background-color: #F9F9F9;
    font-size: 10px;
    border: 1px solid #DDD;
    width: 85px;
    margin-top: 5px;
}
.slider-container input.val-focus {
    border: 1px solid #77A;
    background-color: #FFFFFF;
}
.min-val {
    float: left;
    text-align: left;
    *margin-left: -10px;
    _padding-left: 2px;
}
.slider-container.small .min-val {
    margin-left: 3px;
    *margin-left: -10px;
    _margin-left: 10px;
}
.slider-container.small .max-val {
    margin-right: 30px;
    *margin-right: 12px;
}
.max-val {
    float: right;
    text-align: right;
    _padding-right: 2px;
}
.slider-container .divisions UL {
    list-style-type: none;
    margin: 2px 0px 0px -3px;
    padding: 0px;
}
.slider-container.small .divisions UL {
    margin-top: 0px;
}
.slider-container .divisions UL LI {
    display: inline;
    color: #848E96;
    font-size: 9px;
    font-family: Verdana,  sans-serif;
    float: left;
    text-align: center;
}
.slider-container .divisions UL LI.div-selected {
    color: #38546C;
    font-weight: bold;
}
.basic-criteria {
    height: 140px;
    border-bottom: 1px solid #fff;
}
.slider-container.large {
    width: 227px;
    _margin: 0px 10px 5px 11px;
    _padding: 0;
}
.slider-container.small {
    padding: 0px;
    _margin: 0px 0px 7px 0px;
}
.slider-container.small .ui-slider {
    _margin-left: 10px;
}
.small .ui-slider .ui-slider-handle {
    margin-top: -4px;
}
.small .ui-slider .ui-slider-range {
    height: 14px;
    margin-top: 2px;
}
.small .divisions-label {
    font-size: 9px;
    float: left;
    width: 28px;
    margin-top: 0px;
}
.small .divisions {
    float: left;
}
.slider-container.small input {
    width: 65px;
    margin: 0px;
    padding: 0px;
}
.slider-container.small input .min-val {
    padding-left: 2px;
}
.slider-container.small input .max-val {
    padding-right: 2px;
}
#date-slider-container {
    float: left;
    width: 225px;
    margin: 0;
    padding: 3px 0 0 10px;
    background: #f7f7f7;
    border-left: 1px solid #ffffff;
    height: 41px;
}
#date-slider-container input , #date-slider-container select {
    _margin-left: 3px;
}
#date-slider-container input {
    width: 15px;
    margin-top: 5px;
}
.small .tick {
    height: 10px;
    margin-top: 4px;
    margin-left: -1px;
    line-height: 1px;
}
#date-slider-container input {
    background: none;
    border: none;
    *margin-top: 0px;
}
#cut-slider-container .divisions UL {
    margin-left: -4px;
}
#clarity-slider-container .divisions UL LI {
    width: 27px;
}
#clarity-slider-container .divisions ul li.if {
    width: 23px;
}
#clarity-slider-container .divisions ul li.vvs1,  #clarity-slider-container .divisions ul li.vvs2 {
    width: 33px;
}
.divisions ul.divisions1 li {
    width: 220px !important;
}
.divisions ul.divisions2 li {
    width: 109px !important;
}
.divisions ul.divisions3 li {
    width: 72px !important;
}
.divisions ul.divisions4 li {
    width: 55px !important;
}
.divisions ul.divisions5 li {
    width: 43px !important;
}
.divisions ul.divisions6 li {
    width: 36px !important;
}
.divisions ul.divisions7 li {
    width: 31px !important;
}
#polish-slider.ui-slider ,  #symmetry-slider.ui-slider {
    width: 128px;
    background: url(http://pics.bluenile.com/assets/chrome/builder/byo_thin_short_sliderBgd.gif) no-repeat 0px 3px;
    margin-left: 28px;
}
#depth-slider.ui-slider ,  #table-slider.ui-slider ,  #pricePerCarat-slider.ui-slider ,  #fluorescence-slider.ui-slider {
    width: 154px;
    background: url(http://pics.bluenile.com/assets/chrome/builder/byo_thin_sliderBgd.gif) no-repeat 0px 3px;
}
#lxw-slider.ui-slider {
    width: 157px;
    background: url(http://pics.bluenile.com/assets/chrome/builder/byo_thin_short_sliderBgd.gif) no-repeat 10px 3px;
    _margin-left: 0px;
}
#lxw-slider-container {
    _margin-left: 5px;
}
#fluorescence-slider-container .divisions {
    _margin-left: 3px;
}
#fluorescence-slider-container .divisions UL LI {
    width: 31px;
    _width: 33px;
}
#polish-slider-container .divisions UL LI ,  #symmetry-slider-container .divisions UL LI {
    width: 33px;
    line-height: 1em;
}
#pricePerCarat-slider-container input {
    width: 64px;
}
#price-slider-container .max-val ,  #carat-slider-container .max-val {
    margin-right: 11px;
}
#lxw-slider-container .min-val {
    margin-left: 0;
    *margin-left: -7px;
    _margin-left: -1px;
}
#lxw-slider-container .max-val {
    margin-right: 25px;
    *margin-right: 11px;
    _margin-right: 15px;
}
#polish-slider-container,  #symmetry-slider-container,  #depth-slider-container,  #table-slider-container,  #pricePerCarat-slider-container,  #fluorescence-slider-container,  #lxw-slider-container {
    height: 65px;
    position: absolute;
    left: 0px;
    top: 0px;
    width: 180px;
}
.widget-toggle {
    float: left;
    padding-left: 20px;
    cursor: auto;
}
.widget-disabled {
    cursor: auto;
}
.widget-open-plus {
    background: transparent url(http://pics.bluenile.com/assets/chrome/builder/sprite_icon-diamond-search4.gif) no-repeat scroll 0 -1281px;
    border: none;
    cursor: pointer;
}
.widget-open-minus {
    background: transparent url(http://pics.bluenile.com/assets/chrome/builder/sprite_icon-diamond-search4.gif) no-repeat scroll 0 -1217px;
    border: none;
    cursor: pointer;
}
#carat-slider-container input {
    width: 50px;
}
#ds_grid_body {
    position: relative;
}
#diamondsscrolbar {
    position: absolute;
    right: 0px;
}
.back-to-search {
    display: inline;
    float: right;
    margin: 15px 15px 0 0;
}
.back-to-search img {
    margin-bottom: -1px;
}
.back-to-search a {
    color: #666666;
    font-size: 15px;
    font-variant: small-caps;
    margin: 0;
    padding: 5px 4px 3px 10px;
    text-decoration: none;
}
.static-ship-date {
    color: #666666;
    font-size: 10px;
    margin-top: 6px;
}
.static-ship-date-label {
    color: #5F5F5F;
    font-weight: bold;
}
#ds-feedback a.feedback_link {
    font-family: Verdana, sans-serif;
    font-size: 10px;
    color: #6D6D6D;
    font-weight: bold;
    text-decoration: none;
}
div.diamond_search_feedback_form h2.feedback_hdr {
    font-family: Arial,  sans-serif;
    font-size: 18px;
    font-weight: 500;
    color: #5B7290;
    padding: 0;
    font-variant: normal;
}
div.diamond_search_feedback_form .header-close {
    background: url("http://pics.bluenile.com/assets/chrome/but/but_close_medBlu14x14.gif") no-repeat scroll 77% 5px transparent;
    display: block;
    float: right;
    font-size: 11px;
    font-weight: bold;
    margin: 0 -16px 0 0;
    padding: 4px 40px 10px 20px;
    text-decoration: none;
}
div.diamond_search_feedback_form {
    position: absolute;
    display: none;
    z-index: 2500;
    width: 290px;
    height: 242px;
    padding: 20px;
    background: #F0F0F2;
    border: 1px solid #666;
}
div.diamond_search_feedback_form label,  div.diamond_search_feedback_form input,  div.diamond_search_feedback_form textarea {
    color: #555555;
    font-family: Verdana;
    font-size: 10px;
}
div.diamond_search_feedback_form form div.content_area {
    text-align: left;
    width: 290px;
    margin: 0;
}
div.diamond_search_feedback_form form div label {
    line-height: 16px;
}
div.diamond_search_feedback_form form div.email {
    margin: 5px 7px 10px 0;
}
div.diamond_search_feedback_form form div textarea {
    border: 1px solid #7f9db9;
    margin: 0;
    padding: 0;
    width: 290px;
}
div.diamond_search_feedback_form form div div.submit {
    margin: 8px 0 0 0;
}
div.diamond_search_feedback_form form div div.submit input {
    border: 0 none;
    margin: 0;
    padding: 0;
    float: none;
}
div.email_confirmation {
    margin: 10px 0 0 0;
}
div.diamond_search_feedback_form .thank_you {
    display: none;
}
#question_label.error {
    color: red;
}
div.diamond_search_feedback_form img.feedback_arrow {
    bottom: -13px;
    position: absolute;
    z-index: 10;
    left: 154px;
}
div.diamond_search_feedback_form .content_hdr {
    float: left;
}
div.diamond_search_feedback_form #contact_email_submit {
    left: 137px;
    position: absolute;
}
.email_confirmation {
    display: none;
}
.holiday-text,  .holiday-filter-label {
    color: #AA3347 !important;
}
#holidayShippingMessage {
    display: block;
    left: 15px;
    position: relative;
    top: -14px;
}
#holidayShippingMessage .holiday-message {
    color: #AA3347;
    font-family: Verdana, sans-serif;
    font-size: 12px;
    font-weight: bold;
    padding: 3px 10px 0 0;
    text-align: left;
    vertical-align: middle;
}
#holidayShippingMessage .holiday-message img {
    position: relative;
    top: 3px;
    left: -2px;
}
#holidayShippingMessage .holiday-filter-message {
    font-family: Verdana, sans-serif;
    font-size: 10px;
    padding: 3px 0 0 14px;
    text-align: left;
}
#holidayShippingMessage .holiday-filter-message span {
    color: #AA3347;
}
#product_details .image_viewer .slide {
    height: 315px;
}
#diamonds_details .image_viewer .slide,  #diamonds_details .image_viewer .slides {
    height: 230px;
}
.image_viewer .slides {
    display: none;
}
.image_viewer .slides img.lazy {
    display: none;
}
.image_viewer span.inner-zoom {
    cursor: pointer;
    display: inline-block;
    position: relative;
}
.image_viewer span.inner-zoom img {
    display: block;
}
.image_viewer .thumb {
    float: left;
    list-style: none;
    margin: 5px 2px;
    border: 1px solid #96A9B8;
}
.image_viewer .thumb img {
    border: none;
    display: block;
}
.image_viewer .thumb.selected {
    border: 2px solid #96A9B8;
    margin: 4px 1px;
}
.image_viewer .thumb:hover {
    border: 2px solid #5B7290;
    margin: 4px 1px;
}
.image_viewer .icon {
    display: none;
}
.image_viewer .icon,  .image_viewer .icon.thumb {
    margin: 4px 2px 0 2px;
    list-style: none;
    border: none;
    float: left;
}
.image_viewer .icon.zoom {
    margin: 0;
    position: absolute;
    right: 0;
}
.image_viewer .thumbs {
    margin: 0;
    padding-left: 2px;
    overflow: hidden;
    background-color: #F4F6F8;
    padding-bottom: 3px;
}
.zoom_overlay {
    position: absolute;
    height: 100%;
    width: 100%;
    top: 0;
    left: 0;
    background: url('http://pics.bluenile.com/ai/zoom/btnZoom.gif') center center no-repeat;
    z-index: 10;
    cursor: pointer;
}
.diamond_details_container {
    margin: 0 0 0 25px;
    width: 940px;
    z-index: 1000;
}
.basic_diamond_details .diamond_details_container {
    width: 762px;
    margin: 0px;
}
.diamond_details_container a {
    color: #006699;
}
.diamond_details_container li {
    color: #666666;
    font-size: 10px;
}
#diamonds_details .box-large.light-bg {
    background: url("http://pics.bluenile.com/assets/chrome/shell/light-bg.jpg") no-repeat left top !important;
}
#diamondSearchHeader h2 {
    padding-bottom: 24px;
    float: left;
    width: 700px;
}
#diamonds_details .box-large.light-bg H2 {
    font-size: 32px;
}
#diamonds_details .right-small {
    float: right;
    width: 436px;
}
#diamonds_details .right-small IMG {
    float: right;
}
#diamonds_details .grad-box .details-box .border-container .education A:HOVER {
    text-decoration: none;
}
#diamonds_details .text-frame .education .text,  #diamonds_details .results-box .education .title,  #diamonds_details .grad-box .details-box .border-container .education .title {
    font-family: Arial,  Helvetica,  sans-serif;
    font-size: 18px;
    line-height: 21px;
    color: #B5B59C;
    text-align: center;
    display: inline;
    text-transform: uppercase;
    letter-spacing: 2px;
}
#diamonds_details .grad-box .details-box .border-container .education .title {
    width: 160px;
}
#diamonds_details .grad-box .details-box .border-container .education .message {
    max-width: 50%;
    min-width: 35%;
    border-right: 1px solid #CACABA;
    color: #666666;
    font-size: 10px;
}
#diamonds_details .grad-box .details-box .border-container .education .message span {
    text-transform: uppercase;
    padding-bottom: 10px;
    font-weight: bold;
}
#diamonds_details .grad-box .details-box .border-container .education .title A {
    color: #FFFFFF;
    background-color: #B5B59C;
    display: block;
}
#diamonds_details .grad-box .details-box .border-container .education A.illustration-small {
    float: right;
    width: 60px;
    font-size: 10px;
    color: #666666;
    text-align: center;
    margin: 2px 0 0 2px;
}
#diamonds_details .grad-box .details-box .border-container .education A.illustration-small IMG {
    border: 1px solid #CACABA;
    height: 50px;
    width: 50px;
}
#diamonds_details .grad-box .settings-box {
    background-color: #fff;
    width: 762px;
    float: left;
    margin: 0 0 0 0;
    display: inline;
}
.diamond_details_data {
    background: url("http://pics.bluenile.com/assets/chrome/shell/bgd_details_inset.gif") repeat-x top left;
    border-bottom: 1px solid #96A9B8;
    float: left;
    width: 762px;
    min-height: 282px;
    display: inline;
    padding-bottom: 8px;
    margin-bottom: 2px;
}
.picture-box {
    position: relative;
    width: 385px;
    border: 1px solid #96A9B8;
    background-color: #fff;
    margin: 7px 0 0 7px;
}
.picture-box .picture-large {
    width: 375px!important;
    width: 377px;
    height: 230px;
    float: left;
    margin: 3px 0 0 3px;
    font-size: 1px;
    line-height: 0;
    position: relative;
    text-align: center;
}
#diamonds_details .grad-box .settings-box .picture-box A.shapes {
    position: absolute;
    bottom: 0px!important;
    right: -1!important;
    height: 18px;
    text-decoration: none;
    width: 100%;
}
#diamonds_details .grad-box .settings-box .picture-box A.shapes img {
    float: right;
    margin-left: 3px;
    width: 18px;
    height: 17px;
    font-size: 10px;
    border: 1px solid #96A9B8;
}
#s7_dia_shape_form {
    position: absolute;
    bottom: 1px;
    right: 0px;
    width: 350px;
    height: 19px;
    font-size: 10px;
}
#s7_dia_shape_form input {
    float: right;
    font-size: 10px;
    padding: 0px;
}
#s7_dia_shape_form select {
    float: right;
    font-size: 10px;
}
#diamonds_details .grad-box .settings-box .picture-box A.picture-small {
    float: left;
    border: 1px solid #c7c9ce;
    font-size: 1px;
    line-height: 0;
    margin: 3px 0 0 3px;
}
#diamonds_details .grad-box .settings-box .picture-box A.picture-small.multi_diamond {
    margin: 3px 3px 3px 23px;
}
#diamonds_details .grad-box .settings-box .picture-box A.picture-small IMG {
    border: 1px solid #fff;
}
#diamonds_details .grad-box .settings-box .picture-box A.picture-small:HOVER IMG,  #diamonds_details .grad-box .settings-box .picture-box A.picture-small.selected IMG {
    border-color: #c7c9ce;
}
#diamonds_details .grad-box .settings-box .picture-box A.more {
    float: left;
    background: no-repeat left 1px;
    font-size: 10px;
    color: #A9A9A9;
    padding-left: 13px;
    margin-top: 33px;
}
#diamonds_details .grad-box .settings-box .picture-box A.fewer {
    float: left;
    font-size: 10px;
    color: #A9A9A9;
    padding-left: 13px;
    margin-top: 33px;
}
#diamonds_details .grad-box .settings-box .picture-box P,  #diamonds_details .grad-box .settings-box .picture-box P A {
    color: #006699;
}
#diamonds_details .grad-box .settings-box .picture-box P {
    color: #006699;
    font-size: 10px;
    height: 10px;
    margin: 0 3px 0 0;
    padding: 0;
    text-align: right;
    width: 70px;
}
#diamonds_details .grad-box .settings-box .picture-box .multi_diamond P {
    font-size: 9px;
}
.divider-small {
    border-bottom: 1px solid #E4E5E7;
    margin: 0 40px 10px 20px;
}
.text-box {
    width: 332px;
    margin: 0 0 0 26px;
}
.text-box H3 {
    padding: 0;
    margin: 16px 0 0 0;
    font-size: 24px;
}
.text-box H3 SPAN {
    display: block;
    font-family: Arial,  sans-serif;
    font-size: 15px;
    color: #7F7F7F;
    font-variant: normal;
}
.text-box P {
    padding: 0;
    margin: 8px 6px 0 0;
    font-size: 10px;
    color: #666666;
}
P.error {
    color: #990000!important;
    margin-top: 30px;
}
.add-frame .error {
    font-size: 10px;
    margin-top: 5px;
    margin-bottom: 0;
}
.text-box A.similar_button_large {
    color: #FFFFFF;
    font-size: 14px;
    line-height: 33px;
    margin-top: 7px;
    padding-left: 6px;
    background: transparent url(http://img.bluenile.com/is/image/bluenile/search-for-diamonds-bg) no-repeat scroll left top;
    height: 33px;
    width: 180px;
    display: block;
    padding-left: 6px;
}
.customer-ratings {
    min-height: 36px;
}
* html .customer-ratings {
    height: 36px;
}
.text-box .rating-frame {
    float: left;
    width: 100%;
    font-size: 10px;
    margin-top: 8px;
}
.text-box .rating-frame DIV {
    float: left;
}
.text-box .rating-frame .rating-stars {
    float: left;
}
.text-box .rating-frame .details {
    color: #D9DCDC;
    margin-left: 6px;
}
.text-box .rating-frame .details A {
    color: #7F7F7F;
}
.text-box .rating-frame .details A:HOVER {
    color: #006699;
}
#diamonds_details #shippingCountdown {
    width: 100%;
    float: left;
    font-size: 10px;
    color: #006699;
    border-width: 1px 0;
    border-style: dotted;
    border-color: #96A9B8;
    padding: 6px 0;
    margin-top: 20px;
}
#product_details #shippingCountdown span {
    display: inline;
}
#expiredShippingCountdown {
    color: #666666;
}
.text-box FORM {
    margin: 16px 0 0 0;
    padding: 0;
    float: left;
}
.text-box FORM LABEL {
    font-size: 11px;
    color: #4A7697;
    text-transform: uppercase;
}
.text-box FORM SELECT {
    width: 106px;
    font-size: 10px;
    color: #888888;
    background-color: #fff;
    border: 1px solid #D9DCDC;
}
.text-box form select.add-to-drop-down {
    width: 140px;
}
.text-box A.ring-size {
    float: right;
    font-size: 10px;
    color: #006699;
    background: no-repeat left 2px;
    padding-left: 12px;
    margin: 18px 0 0 0;
}
.text-box .price {
    margin: 34px 0 0 0;
    font-size: 15px;
    color: #006699;
}
.text-box .price STRONG {
    letter-spacing: 1px;
    color: #666666;
    text-transform: uppercase;
}
#vat-text,  .vat-text {
    font-size: 10px;
    color: #7F7F7F;
}
.included {
    color: #666666;
    font-size: 11px;
    margin-bottom: 4px;
    margin-top: 4px;
    font-weight: bold;
}
.back-to-search,  #back_to_details {
    display: inline;
    float: right;
    margin: 15px 15px 0 0;
}
#diamondSearchHeader .back-to-search {
    margin-top: 50px;
}
.back-to-search img,  #back_to_details img {
    margin-bottom: -1px;
}
.back-to-search a,  #back_to_details a {
    color: #666666;
    font-size: 15px;
    font-variant: small-caps;
    margin: 0;
    padding: 5px 4px 3px 10px;
    text-decoration: none;
}
A.buttonLg {
    color: white;
    margin-top: 7px;
    text-transform: lowercase;
}
.other-add-selections {
    color: #7596b7;
    width: 176px;
    display: none;
    position: absolute;
    border-left: 1px solid #7596b7;
    border-right: 1px solid #7596b7;
    background: #EFF1F5 url(http://pics.bluenile.com/assets/chrome/shell/arrow-link-arrow_bot.gif) center bottom no-repeat;
    z-index: 11;
}
A.other-selection {
    display: block;
    width: 168px;
    font-size: 10px;
    margin: 0;
    padding: 0px 0px 5px 5px;
    background: #EFF1F5 url(http://pics.bluenile.com/assets/chrome/icons/sidebar-menu-arrow.gif) right 4px no-repeat;
    border-bottom: 1px dotted #FFFFFF;
}
A.other-selection:hover {
}
.text-box .icons {
    padding: 10px 0 10px 0;
    text-align: left;
}
.text-box .icontext {
    font-size: 10px;
}
.text-box .icontext .detailsIcon {
    position: relative;
    top: 3px;
}
#diamonds_details .grad-box .details-box {
    float: left;
    width: 100%;
}
#diamonds_details .grad-box .details-box .border-container {
    border-top: 1px solid #96A9B8;
    padding-bottom: 40px;
    float: left;
    width: 762px!important;
    width: 764px;
}
#diamonds_details .grad-box .details-box .border-container H3 {
    padding: 4px 0 4px 6px;
    margin: 0;
    font-size: 20px;
    border-bottom: 1px solid #96A9B8;
}
#diamonds_details .grad-box .details-box .border-container H3.top-ind {
    margin-top: 10px;
}
#diamonds_details .grad-box .details-box .border-container H3 A {
    background: url("http://pics.bluenile.com/assets/chrome/icons/sidebar-menu-arrow.gif") no-repeat right 7px;
    padding-right: 18px;
}
#diamonds_details .grad-box .details-box .border-container .column {
    float: left;
    font-size: 10px;
    width: 340px;
    margin: 0 16px 0 14px;
    padding-top: 6px;
    display: inline;
}
#diamonds_details .grad-box .details-box .border-container .cert_views {
    width: 400px;
    margin: 0 0px 0 0px;
    float: left;
    font-size: 10px;
    padding-top: 6px;
    display: inline;
}
#diamonds_details .grad-box .details-box .border-container .cert_desc {
    float: left;
    font-size: 10px;
    width: 340px;
    margin: 0 5px 0 14px;
    padding-top: 6px;
    display: inline;
}
#diamonds_details .grad-box .details-box .border-container .column P {
    padding: 2px 0 3px 0;
    margin: 0;
    border-bottom: 1px solid #E4E5E7;
    font-size: 10px;
    color: #666666;
}
#diamonds_details .grad-box .details-box .border-container .column P A {
    color: #006699;
}
#diamonds_details .grad-box .details-box .border-container .column H5 {
    padding: 5px 0 4px 0;
    margin: 0;
    font-size: 10px;
    color: #666666;
    text-transform: uppercase;
}
#diamonds_details .grad-box .details-box .border-container .column H5.no-transform {
    text-transform: none;
}
#diamonds_details .grad-box .details-box .border-container .column TABLE {
    width: 100%;
}
#diamonds_details .grad-box .details-box .border-container .column TABLE TD {
    border-bottom: 1px solid #E4E5E7;
    border-left: none;
    border-right: none;
    border-top: none;
    color: #666666;
    padding: 2px 0 3px 0;
    vertical-align: bottom;
}
#diamonds_details .grad-box .details-box .border-container .column TABLE TD.small {
    width: 30%;
    text-align: right;
}
#diamonds_details .grad-box .details-box .border-container .column TABLE TD.medium {
    width: 50%;
    text-align: right;
}
#diamonds_details .column TABLE TD A {
    display: block;
    color: #006699;
}
#diamonds_details .grad-box .details-box .border-container .column TABLE TD A.no-indent {
    margin: 0;
}
#diamonds_details .grad-box .details-box .border-container .column TABLE TD A.choose-size {
    background: no-repeat left 2px;
    padding-left: 12px;
}
#diamonds_details .grad-box .details-box .border-container .internal .column P {
    margin: 10px 0 3px 0;
}
#diamonds_details .grad-box .details-box .border-container .internal .column TABLE {
    margin-top: 10px;
}
#diamonds_details .grad-box .details-box .border-container .internal .column TABLE TH {
    color: #666666;
    text-align: left;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels {
    float: left;
    width: 364px;
    background-color: #EFEFEC;
    margin-top: 8px;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .box {
    margin: 2px;
    border: 1px solid #fff;
    padding-bottom: 4px;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-rating {
    width: 118px;
    float: left;
    background: #fff repeat-x top left;
    border-width: 0 1px 1px 0;
    border-style: solid;
    border-color: #929292;
    margin: 5px 0 0 8px;
    display: inline;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-rating TABLE {
    width: 110px;
    margin: 4px;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-rating TABLE TD {
    font-size: 10px;
    color: #666666;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-rating TABLE TR.with-border TD {
    border-bottom: 1px solid #CAC9CA;
    padding-bottom: 3px;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-rating TABLE TD.small {
    width: 10%;
    text-align: right;
    padding-right: 2px;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-result {
    float: left;
    width: 200px;
    margin: 10px 0 0 20px;
    display: inline;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-result P {
    padding: 0;
    margin: 8px 0 0 0;
    font-size: 10px;
    color: #666666;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-result P.link {
    background: url("http://pics.bluenile.com/assets/chrome/icons/sidebar-menu-arrow_on.gif") no-repeat left 2px;
    padding-left: 16px;
}
#diamonds_details .grad-box .details-box .border-container .rating-levels .average-result P.link A {
    color: #006699;
}
.rating-levels {
    float: left;
    width: 364px;
    background-color: #EFEFEC;
    margin-top: 8px;
}
.rating-levels .box {
    margin: 2px;
    border: 1px solid #fff;
    padding-bottom: 4px;
}
.rating-levels .average-rating {
    width: 118px;
    float: left;
    background: #fff url("http://pics.bluenile.com/assets/images/item/item_rating_tile.gif") repeat-x top left;
    border-width: 0 1px 1px 0;
    border-style: solid;
    border-color: #929292;
    margin: 5px 0 0 8px;
    display: inline;
}
.rating-levels .average-rating TABLE {
    width: 110px;
    margin: 4px;
}
.rating-levels .average-rating TABLE TD {
    border-style: none;
    font-size: 10px;
    color: #666666;
    padding: 0;
}
.rating-levels .average-rating TABLE TR.with-border TD {
    border-style: none;
    border-bottom: 1px solid #CAC9CA;
    padding-bottom: 3px;
}
.rating-levels .average-rating TABLE TD.small {
    width: 10%;
    text-align: right;
    padding: 0 2px 0 0;
}
.rating-levels .average-result {
    float: left;
    width: 200px;
    margin: 10px 0 0 20px;
    display: inline;
}
.rating-levels .average-result P {
    padding: 0;
    margin: 8px 0 0 0;
    font-size: 10px;
    color: #666666;
}
#diamonds_details .grad-box .details-box .border-container .feedbacks {
    float: none;
    width: auto;
    margin: 0 0 0 10px;
}
#diamonds_details .grad-box .details-box .border-container .feedbacks H5 {
    padding: 0;
    margin: 10px 0 0 2px;
    font-size: 10px;
    color: #666666;
}
#diamonds_details .grad-box .details-box .border-container .feedbacks P {
    padding: 0;
    margin: 0;
    font-size: 9px;
    color: #666;
}
#diamonds_details .grad-box .details-box .border-container .feedbacks P.author {
    font-style: italic;
    margin-top: 4px;
}
.feedbackItem {
    display: inline-table;
    width: 365px;
    float: left;
}
.all_feedback {
    border: 1px solid #D9DCDC;
    padding-bottom: 40px;
    float: left;
    width: 764px;
}
.feedback-heading {
    padding: 0;
    margin: 10px 0 0 2px;
    font-size: 10px;
    color: #666666;
    font-weight: bold;
}
#diamonds_details .grad-box .details-box .border-container .add-frame {
    float: right;
    width: 356px;
}
#diamonds_details .grad-box .details-box .border-container .add-frame IMG,  #diamonds_details .grad-box .details-box .border-container .add-frame .buttonLg {
    margin: 0 30px 0 0;
}
#diamonds_details .grad-box .details-box .border-container .add-frame .buttonLg {
    margin: 40px 30px 0 0;
}
.packaging_img {
    float: right;
    margin-right: 90px;
}
#diamonds_details .grad-box .details-box .border-container P.note {
    padding: 0;
    margin: 20px 20px 0 20px;
    font-size: 10px;
    color: #666;
    text-align: left;
}
#diamonds_details .grad-box .details-box .border-container P.note.small-ind {
    margin-top: 10px;
}
#diamonds_details .grad-box .details-box .border-container P.note A {
    color: #660F57;
    text-decoration: underline;
}
#diamonds_details .grad-box .details-box .border-container P.note A:HOVER {
    text-decoration: none;
}
#diamonds_details .grad-box .details-box #shipping-details {
    margin-bottom: 15px;
}
#diamonds_details .grad-box .details-box #financing-container {
    color: #666666;
    height: 100px;
    overflow: hidden;
}
#diamonds_details .grad-box .details-box #financing-container div {
    float: left;
    font-size: 10px;
    line-height: 15px;
    margin: 9px 0 0 14px;
}
#diamonds_details .grad-box .details-box #financing-container div.financing-summary {
    padding-right: 80px;
    width: 260px;
}
#diamonds_details .grad-box .details-box #financing-container div.financing-details div {
    float: none;
    margin: 0 0 0 2em;
}
#diamonds_details .grad-box .details-box #financing-container div.financing-details ul {
    margin: 0 0 3px 0;
}
#diamonds_details .grad-box .details-box #financing-container div.financing-details ul li {
    margin: 0 1em 0 2em;
}
#diamonds_details .grad-box .details-box #add-to-basket-container {
    border-top: 1px solid #96A9B8;
    padding-top: 4px;
}
#diamonds_details .grad-box .details-box .comes-with {
    display: inline;
    float: left;
    margin: 0 27px 0 20px;
}
#diamonds_details .grad-box .details-box .packaging-hero {
    float: left;
    width: 100px;
}
#diamonds_details .grad-box .details-box .comes-with h4 {
    color: #666666;
    font-size: 11px;
    margin-bottom: 4px;
    margin-top: 4px;
}
#diamonds_details .grad-box .details-box .comes-with a {
    color: #006699;
    display: inline;
    margin-top: 4px;
    font-size: 10px;
}
.comes-with .other-cert-selections {
    width: 103px;
}
.byo_content_area {
    background: url('http://pics.bluenile.com/assets/chrome/bg/builder_bg.gif') repeat scroll left top #FFFFFF;
    margin: 0;
    padding: 0;
    _display: inline-block;
}
.byo_bridge_cap {
    border-top: 1px solid #006699;
    width: 177px;
}
.byo_bridge_cap_container {
    clear: both;
    overflow: hidden;
    position: relative;
}
.non_builder_sidebar {
    margin: 0 0 0 0;
    overflow: hidden;
    padding: 0px 0px 0px 0px;
    vertical-align: top;
    width: 175px;
}
.non_builder_main {
    background: none #FFFFFF;
    _overflow: hidden;
    width: 762px;
}
.byo_bridge_steps .step H2.blue-text {
    color: #006699;
    font-size: 10px;
    font-weight: bold;
    font-family: Verdana,  Geneva,  Arial,  Helvetica,  sans-serif;
}
.byo_bridge_steps .step.with-border P A {
    color: #888;
}
.byo_bridge_steps .step-border {
    line-height: 0;
    font-size: 1px;
}
.byo_bridge_steps {
    height: 620px;
    text-align: center;
    float: right;
}
.diamond_details_container .byo_bridge_steps {
    margin-top: -27px;
}
.byo_bridge_steps .module-container {
    padding: 20px 9px 10px;
}
.byo_bridge_steps .module-container H1 {
    font-size: 21px;
    color: #0e1d42;
}
.byo_bridge_steps .module-container H1 SUP {
    font-size: 0.6em;
    margin: 0 0 8px 1px;
}
.byo_bridge_steps .module {
    margin: 10px 0 0 0;
}
.byo_bridge_steps a {
    color: #006699;
    font-size: 10px;
    font-weight: bold;
    font-family: Verdana,  Geneva,  Arial,  Helvetica,  sans-serif;
    margin-bottom: 2px;
    cursor: pointer;
}
.byo_bridge_steps a img {
    border: 1px solid #96a9b8;
}
.cert_helper_box {
    float: left;
    font-size: 10px;
}
.cert_helper a.cert_link {
    width: 70px;
    display: block;
}
.text-box .cert_helper_box {
    margin-top: 10px;
}
.text-box .cert_helper_box .cert_helper {
    float: left;
}
.cert_small .cert_helper {
    margin-left: 32px;
    margin-top: 5px;
}
.cert_helper .other-cert-selections {
    border-left: 1px solid #96a9b8;
    border-right: 1px solid #96a9b8;
    border-bottom: 1px solid #96a9b8;
    display: none;
    position: absolute;
    width: 70px;
    z-index: 10;
}
.cert_helper .other-cert-selection {
    background: #F1F0F0 url(http://pics.bluenile.com/assets/chrome/icons/sidebar-menu-arrow.gif) right 4px no-repeat;
    cursor: pointer;
    padding: 0 0 5px 2px;
}
.cert_helper .other-cert-selection a {
    display: inline !important;
}
.cert_lab_description {
    color: #666666;
    margin-bottom: 10px;
}
.cert_small {
    float: left;
    font-size: 10px;
    position: relative;
    width: 90px;
}
.cert_small a {
    color: #006699;
}
.cert_small img {
    border: 1px solid #96a9b8;
}
.cert_view_links {
    color: #666666;
    float: left;
    margin-top: 5px;
    max-width: 150px;
    padding-right: 10px;
}
#ccc_overview {
    color: #666666;
    font-size: 10px;
    margin-top: 9px;
    width: 750px;
}
.ccc_overview_div {
    float: left;
    margin-left: 13px;
    margin-right: 0px;
}
#ccc_cut_div {
    width: 260px;
}
#ccc_color_div {
    width: 180px;
}
#ccc_clarity_div {
    width: 255px;
}
#ccc_color_div .ccc_list {
    font-size: 9px;
    margin-right: 43px;
}
#ccc_clarity_div .ccc_list,  #ccc_cut_div .ccc_list {
    font-size: 9px;
}
.ccc_list {
    background-color: #f1f0f0;
    margin-bottom: 3px;
    padding: 3px 0 0 3px;
}
.ccc_selected_span {
    background-color: #ffffff;
    border: 1px solid #96a9b8;
    padding-left: 1px;
    padding-right: 1px;
}
.ccc_text {
    font-size: 9px;
}
.multi_dia_header {
    test-align: left;
}
.multi_dia_header th {
    border: none !important;
    border-width: 0px 0px 0px 0px;
    color: #666666;
    text-align: left;
    padding-left: 0px;
}
.separatorline {
    margin: 20px 20px 0px 20px;
    border-bottom: 1px solid #BBBCBE;
    padding-bottom: 0px;
}
UL.product-list {
    padding: 0;
    margin: 0px 0px 0px 0px;
}
UL.product-list LI {
    list-style: none;
    font-size: 10px;
    line-height: 13px;
    margin-top: 4px;
}
UL.product-list LI A {
    color: #006699;
    font-weight: bold;
}
.view_cert_text {
    margin: 0px 0px 0px 0px;
    background: url("http://img.bluenile.com/is/image/bluenile/list-style-icon") no-repeat left 3px;
    padding-left: 7px;
}
div.pp_pic_holder .pp_top .pp_left {
    background: url(http://pics.bluenile.com/ai/zoom/tl.gif) top left no-repeat;
}
div.pp_pic_holder .pp_top .pp_middle {
    background: #fff;
}
div.pp_pic_holder .pp_top .pp_right {
    background: url(http://pics.bluenile.com/ai/zoom/tr.gif) top left no-repeat;
}
div.pp_pic_holder .pp_content {
    background-color: #fff;
}
div.pp_pic_holder .pp_content a.pp_next:hover {
    background: url(http://pics.bluenile.com/assets/chrome/zoom/btnNext.gif) center right no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content a.pp_previous:hover {
    background: url(http://pics.bluenile.com/assets/chrome/zoom/btnPrevious.gif) center left no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content a.pp_expand {
    background: url(http://pics.bluenile.com/ai/zoom/btnExpand.gif) top left no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content a.pp_expand:hover {
    background: url(http://pics.bluenile.com/ai/zoom/btnExpand.gif) bottom left no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content a.pp_contract {
    background: url(http://pics.bluenile.com/ai/zoom/btnContract.gif) top left no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content a.pp_contract:hover {
    background: url(http://pics.bluenile.com/ai/zoom/btnContract.gif) bottom left no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content .pp_close {
    width: 75px;
    height: 23px;
    margin-top: 5px;
    background: url(http://pics.bluenile.com/assets/chrome/zoom/btnClose.gif) center left no-repeat;
    cursor: pointer;
}
div.pp_pic_holder .pp_content .pp_details .pp_nav .pp_arrow_previous {
    background: url(http://pics.bluenile.com/assets/chrome/zoom/arrow_previous.gif) top left no-repeat;
}
div.pp_pic_holder .pp_content .pp_details .pp_nav .pp_arrow_next {
    background: url(http://pics.bluenile.com/assets/chrome/zoom/arrow_next.gif) top left no-repeat;
}
div.pp_pic_holder .pp_bottom .pp_left {
    background: url(http://pics.bluenile.com/ai/zoom/bl.gif) top left no-repeat;
}
div.pp_pic_holder .pp_bottom .pp_middle {
    background: #fff;
}
div.pp_pic_holder .pp_bottom .pp_right {
    background: url(http://pics.bluenile.com/ai/zoom/br.gif) top left no-repeat;
}
div.pp_pic_holder .pp_loaderIcon {
    background: url(http://pics.bluenile.com/ai/zoom/loader.gif) center center no-repeat;
}
div.ppt div.ppt_left {
    background: url(http://pics.bluenile.com/ai/zoom/ttl.gif) top left no-repeat;
}
div.ppt div.ppt_right {
    background: url(http://pics.bluenile.com/ai/zoom/ttr.gif) top left no-repeat;
}
div.ppt div.ppt_content {
    background: url(http://pics.bluenile.com/ai/zoom/ttp.gif) top left repeat-x;
}
div.light_square .pp_top .pp_left ,  div.light_square .pp_top .pp_middle,  div.light_square .pp_top .pp_right,  div.light_square .pp_bottom .pp_left,  div.light_square .pp_bottom .pp_middle,  div.light_square .pp_bottom .pp_right,  div.light_square .pp_content,  div.light_square div.ppt_left,  div.light_square div.ppt_right,  div.light_square div.ppt_content {
    background: #fff;
}
div.light_square div.ppt_content {
    color: #666666;
}
div.pp_pic_holder a:focus {
    outline: none;
}
div.pp_overlay {
    background: #000;
    position: absolute;
    top: 0;
    left: 0;
    z-index: 9500;
    width: 100%;
}
div.pp_pic_holder {
    position: absolute;
    z-index: 10000;
    width: 100px;
}
div.pp_pic_holder .pp_top {
    position: relative;
    height: 20px;
}
  </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="shape-slider-container" class="slider-container large">
<h3 data-filter-type="Shape">Shape</h3>
<ul id="shape">
<li class="selected"><span data-shapeid="RD" id="RD_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_RD_ON">
<input type="checkbox" checked="checked" name="shape" value="RD" id="shapeRD">
<label for="shapeRD">Round</label>
</span></li>
<li><span data-shapeid="PR" id="PR_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_PR_OFF">
<input type="checkbox" name="shape" value="PR" id="shapePR">
<label for="shapePR">Princess</label>
</span></li>
<li><span data-shapeid="EC" id="EC_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_EC_OFF">
<input type="checkbox" name="shape" value="EC" id="shapeEC">
<label for="shapeEC">Emerald</label>
</span></li>
<li><span data-shapeid="AS" id="AS_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_AS_OFF">
<input type="checkbox" name="shape" value="AS" id="shapeAS">
<label for="shapeAS">Asscher</label>
</span></li>
<li><span data-shapeid="MQ" id="MQ_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_MQ_OFF">
<input type="checkbox" name="shape" value="MQ" id="shapeMQ">
<label for="shapeMQ">Marquise</label>
</span></li>
<li><span data-shapeid="OV" id="OV_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_OV_OFF">
<input type="checkbox" name="shape" value="OV" id="shapeOV">
<label for="shapeOV">Oval</label>
</span></li>
<li><span data-shapeid="RA" id="RA_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_RA_OFF">
<input type="checkbox" name="shape" value="RA" id="shapeRA">
<label for="shapeRA">Radiant</label>
</span></li>
<li><span data-shapeid="PS" id="PS_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_PS_OFF">
<input type="checkbox" name="shape" value="PS" id="shapePS">
<label for="shapePS">Pear</label>
</span></li>
<li><span data-shapeid="HS" id="HS_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_HS_OFF">
<input type="checkbox" name="shape" value="HS" id="shapeHS">
<label for="shapeHS">Heart</label>
</span></li>
<li><span data-shapeid="CU" id="CU_icon" class="sprite_byo_shape_icon sprite-but_byo_shape_CU_OFF">
<input type="checkbox" name="shape" value="CU" id="shapeCU">
<label for="shapeCU">Cushion</label>
</span></li>
</ul> </div>
   <div id="carat-slider-container" class="slider-container large">
<h3 data-filter-type="Carat">Carat</h3>
<div id="carat-slider" class="ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all">
<img class="ui-slider-range ui-widget-header" src="/assets/themes/img/loosediamonds/bar.gif" style="left: 0%; width: 100%;">
<img class="ui-slider-handle left-handle ui-state-default ui-corner-all" style="padding: 16px 20px 16px 0px; top: -16px; left: 0%;" src="/assets/themes/img/loosediamonds/left_slider.gif">
<img class="ui-slider-handle right-handle ui-state-default ui-corner-all ui-state-focus" style="padding: 16px 20px 16px 0px; top: -16px; left: 100%;" src="/assets/themes/img/loosediamonds/right_slider.gif">
</div>
<input type="text" name="minCarat" id="carat-min-value" class="min-val range-value" value="0.23">
<input type="text" name="maxCarat" id="carat-max-value" class="max-val range-value" value="21.12">
<div class="cb"></div>
</div>
<div id="color-slider-container" class="slider-container large">
<h3 data-filter-type="Color">Color</h3>
<div id="color-slider" class="ui-slider ui-slider-horizontal ui-widget ui-widget-content ui-corner-all">
<img class="ui-slider-range ui-widget-header" src="/assets/themes/img/loosediamonds/bar.gif" style="left: 0%; width: 100%;">
<img class="ui-slider-handle left-handle ui-state-default ui-corner-all" style="padding: 16px 20px 16px 0px; top: -16px; left: 0%;" src="/assets/themes/img/loosediamonds/left_slider.gif">
<img class="ui-slider-handle right-handle ui-state-default ui-corner-all" style="padding: 16px 20px 16px 0px; top: -16px; left: 100%;" src="/assets/themes/img/loosediamonds/right_slider.gif">
<div class="tick" style="left: 25.857142857142858px; "></div><div class="tick" style="left: 57.714285714285715px; "></div><div class="tick" style="left: 89.57142857142857px; "></div><div class="tick" style="left: 121.42857142857143px; "></div><div class="tick" style="left: 153.28571428571428px; "></div><div class="tick" style="left: 185.14285714285714px; "></div></div>
<div class="divisions">
<ul class="divisions7">
<li data-value="J" class="     div-selected">J</li>
<li data-value="I" class="    div-selected">I</li>
<li data-value="H" class="   div-selected">H</li>
<li data-value="G" class="   div-selected">G</li>
<li data-value="F" class="   div-selected">F</li>
<li data-value="E" class="   div-selected">E</li>
<li data-value="D" class=" div-selected">D</li>
</ul>
</div>
<div class="cb"></div>
<input type="hidden" name="minColor" id="color-min-value" class="min-val range-value" value="J" min-bounds="J">
<input type="hidden" name="maxColor" id="color-max-value" class="max-val range-value" value="D" max-bounds="D">
<div class="cb"></div>
</div>

<a id="simple" href="#">Simple message</a>
    </form>
</body>
</html>
