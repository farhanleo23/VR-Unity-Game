<!DOCTYPE html>
<html>
<head>
<title>Demo</title>
<style>
#div1 {margin:10px;font-size:1.25em;}
table {border-collapse:collapse;border:1px solid #7f7f7f;}
td {border:1px solid #7f7f7f;width:50px;height:50px;text-align:center;}

</style>
</head>
<body >

<div id="div1"></div>

<script>
var totalRows = 8;
var cellsInRow = 8;
var min = 1;
var max = 100;

    function drawTable() {
        // get the reference for the body
        var div1 = document.getElementById('div1');

        // creates a <table> element
        var tbl = document.createElement("table");

        // creating rows
        for (var r = 0; r < totalRows; r++) {
            var row = document.createElement("tr");

	     // create cells in row
             for (var c = 0; c < cellsInRow; c++) {
                var cell = document.createElement("td");
								
								if(c<cellsInRow-1 && r<totalRows-1){
		getRandom = Math.floor(Math.random() * (max - min + 1)) + min;
                var cellText = document.createTextNode(Math.floor(Math.random() * (max - min + 1)) + min);
                cell.appendChild(cellText);
							}
                row.appendChild(cell);
            }

	tbl.appendChild(row); // add the row to the end of the table body
        }
calculatation();

if (tbl != null) {
    for (var i = 0; i < tbl.rows.length-1; i++) {
        for (var j = 0; j < tbl.rows[i].cells.length-1; j++)
        tbl.rows[i].cells[j].onclick = function () {
            tableText(this);
        };
    }
}

function tableText(tableCell) {
    tableCell.innerHTML = "";
		tableCell.contentEditable = true;
		tableCell.addEventListener("keyup", event => {
      calculatation();
    }
  );



}

function calculatation(){
	//if(tableCell.value != null)
	var sum = 0;
	// Enters value for the last column
	for (var i = 0; i < tbl.rows.length-1; i++) {
			for (var j = 0; j < tbl.rows[i].cells.length-1; j++){
				sum += Number(tbl.rows[i].cells[j].innerHTML);
			}
tbl.rows[i].cells[7].innerHTML = sum;
sum = 0;
	}

	//Enters value for the last rows
	for (var i = 0; i < 7; i++) {
			for (var j = 0; j < 7; j++){
				sum += Number(tbl.rows[j].cells[i].innerHTML);
			}
tbl.rows[7].cells[i].innerHTML = sum;
sum = 0;
	}

var total = 0;
	//enter the last cells
	for (var i=0; i<7; i++){
		total += Number(tbl.rows[7].cells[i].innerHTML);
	}
	tbl.rows[7].cells[7].innerHTML = total;
	total = 0;
}

     div1.appendChild(tbl); // appends <table> into <div1>
}
window.onload=drawTable;
</script>
</body>
</html>
