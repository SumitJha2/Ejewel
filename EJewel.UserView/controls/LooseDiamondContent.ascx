<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LooseDiamondContent.ascx.cs" Inherits="EJewel.UserView.controls.LooseDiamondContent" %>
<!--Loose Diamond Content-->
<div id="result-container" class="shadow-separator">
                    <div class="row-fluid">
                        <div class="span10">
                            <div id="resultTab-container">
                                <ul class="tabs">
                                    <li><a href="#" rel="view-results"><span id="resultTab">Result</span></a></li>
                                    <li><a href="#" rel="view-comparison"><span id="compareTab">Comparison</span></a></li>
                                </ul>
                                <div class="tabcontents">
                                    <div id="view-results" class="tabcontent">
                                        <table id="ResultsTable"  class="table table-bordered table-striped center_stone_table" >
                                           <thead>
                                            <tr>
                                            <th>Compare</th>
                                            <th>Shape</th>
                                            <th><a href="javascript:void(0)">Carat</a></th>
                                            <th>Cut</th>
                                            <th>Color</th>
                                            <th>Clarity</th>
                                            <th><a href="javascript:void(0)">Price</a></th>
                                            <th>Details</th>
                                            </tr>
                                            </thead>
                                            <tbody id="tblLooseDiamondData">

                                            </tbody>
                                        </table>

                                        <div class="row-fluid">
                                            <div class="span2">
                        <select id="ddlPerpage" style="width:70px;">
                        <option value="10" selected="selected">10</option>
                        <option value="20" >20</option>
                        <option value="50">50</option>
                        <option value="100">100</option>
                        </select>
                        </div>

                                            <div class="span10">
                        <div id="Pagination" style="float:right;" class="pagination"></div>
                        </div>
                                      </div>
                                    </div>
                                    <div id="view-comparison" class="tabcontent">
                                    <table  class="center_stone_table table table-bordered table-striped">
                                    <thead>
                            <tr>
                                <th>Remove</th>
                                <th>Shape</th>
                                <th>Carat</th>
                                <th>Cut</th>
                                <th>Color</th>
                                <th>Clarity</th>
                                <th>Price</th>
                                <th>Details</th>
                            </tr>
                        </thead>
                        <tbody id="tblLooseDiamondCompareData">
                        </tbody>
                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span2">                            
                            <div id="ds_diamond_details">
                            <span><b>Diamond Details</b></span><br />
                            <div id="loose_diamond_overview"></div>
                            </div>
                        </div>
                    </div>
                </div>
<!--Loose Diamond Content End-->