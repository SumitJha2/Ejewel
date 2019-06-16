/*
------------------------------
PARTHA RANJAN NAYAK
12-03-13
This script generate the table
-----------------------------
*/
function create_row(arr_2d) {
    var row = document.createElement("tr");
    if (typeof arr_2d != "undefined") {
        var total_length = arr_2d.length;
        if (total_length > 0) {
            for (var i = 0; i < total_length; i++) {
                row.setAttribute(arr_2d[i][0], arr_2d[i][1]);
            }
        }
    }
    return row;
}
//create cell
function create_cell(row, cellText, arr_2d) {
    var cell = document.createElement("td");
    cell.innerHTML = cellText;
    //set attribute
    if (typeof arr_2d != "undefined") {
        var total_length = arr_2d.length;
        if (total_length > 0) {
            for (var i = 0; i < total_length; i++) {
                cell.setAttribute(arr_2d[i][0], arr_2d[i][1]);
            }
        }
    }
    row.appendChild(cell);
    return row;
}
//add row
function add_row(table_body_id, row) {
    var table_body = document.getElementById(table_body_id);
    table_body.appendChild(row);
}