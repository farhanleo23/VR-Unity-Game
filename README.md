<html>
<head>
<title>JavaScript</title>
<h1>Question 1 </h1>
<style>
#myProgress {
  width: 100% = 490;
  background-color: #ddd;
}

#myBar {
  width: 10%;
  height: 30px;
  background-color: #4CAF50;
  text-align: center;
  line-height: 30px;
  color: white;
}

table, th, td {
  background-color:black;
  border: 5px ;
  border-color:green;
  border-style: groove;
  border-radius:5px;
}
th, td {
color:white;
font-weight:bold;
	padding: 10px;
	text-align: center;
	width: 75px;
  height: 75px;
}
</style>
<script>
var maxSum = 196;
var numbers = [];

function changeValueForCell(){
	var table = document.getElementById("table1");
	for (var i=0; i<8; i++) {
		for (var j=0; j<8; j++) {
			table.rows[i].cells[j].innerHTML = numbers[i][j];
		}
	}
}

function lastRowValues(){
	for(i=0; i < 7; i++){
		rowsum=0;
		for(j=0; j < 7; j++){
			rowsum += numbers[i][j];
		}
		numbers[i][7] = rowsum;
	}
	for(j=0; j < 7; j++){
		colsum = 0;
		for(i=0; i < 7; i++){
			colsum += numbers[i][j];
		}
		numbers[7][j] = colsum;
	}

	lastsum = 0;
	for(i=0; i < 7; i++){
		lastsum += numbers[i][7];
		lastsum += numbers[7][i];
	}
	numbers[7][7] = lastsum;
}

function changeNumbers(){
	for(i=0; i < 7; i++){
		numbers[i] = [];
		for(j=0; j < 7; j++){
			numbers[i][j] = Math.floor(Math.random()*10);
		}
	}

	numbers[7] = [];
	lastRowValues();

	changeValueForCell();
}

function effectRowCol(row, col){
	numbers[row][col] = Math.floor(Math.random()*10);
	lastRowValues();
	changeValueForCell();
}
</script>
</head>
<body>
<center>
	<table id=table1>
		<tr id="row1">
			<td id="R1C1" onclick="effectRowCol(0,0)">cell</td>
			<td id="R1C2" onclick="effectRowCol(0,1)">cell</td>
			<td id="R1C3" onclick="effectRowCol(0,2)">cell</td>
			<td id="R1C4" onclick="effectRowCol(0,3)">cell</td>
			<td id="R1C5" onclick="effectRowCol(0,4)">cell</td>
			<td id="R1C6" onclick="effectRowCol(0,5)">cell</td>
			<td id="R1C7" onclick="effectRowCol(0,6)">cell</td>
			<td id="R1C8" onclick="effectRowCol(0,7)">cell</td>
		</tr>
		<tr id="row2">
			<td id="R2C1" onclick="effectRowCol(1,0)">cell</td>
			<td id="R2C2" onclick="effectRowCol(1,1)">cell</td>
			<td id="R2C3" onclick="effectRowCol(1,2)">cell</td>
			<td id="R2C4" onclick="effectRowCol(1,3)">cell</td>
			<td id="R2C5" onclick="effectRowCol(1,4)">cell</td>
			<td id="R2C6" onclick="effectRowCol(1,5)">cell</td>
			<td id="R2C7" onclick="effectRowCol(1,6)">cell</td>
			<td id="R2C8" onclick="effectRowCol(1,7)">cell</td>
		</tr>
		<tr id="row3">
			<td id="R3C1" onclick="effectRowCol(2,0)">cell</td>
			<td id="R3C2" onclick="effectRowCol(2,1)">cell</td>
			<td id="R3C3" onclick="effectRowCol(2,2)">cell</td>
			<td id="R3C4" onclick="effectRowCol(2,3)">cell</td>
			<td id="R4C5" onclick="effectRowCol(2,4)">cell</td>
			<td id="R4C6" onclick="effectRowCol(2,5)">cell</td>
			<td id="R4C7" onclick="effectRowCol(2,6)">cell</td>
			<td id="R4C8" onclick="effectRowCol(2,7)">cell</td>
		</tr>
		<tr id="row4">
			<td id="R4C1" onclick="effectRowCol(3,0)">cell</td>
			<td id="R4C2" onclick="effectRowCol(3,1)">cell</td>
			<td id="R4C3" onclick="effectRowCol(3,2)">cell</td>
			<td id="R4C4" onclick="effectRowCol(3,3)">cell</td>
			<td id="R4C5" onclick="effectRowCol(3,4)">cell</td>
			<td id="R4C6" onclick="effectRowCol(3,5)">cell</td>
			<td id="R4C7" onclick="effectRowCol(3,6)">cell</td>
			<td id="R4C8" onclick="effectRowCol(3,7)">cell</td>
		</tr>
		<tr id="row5">
			<td id="R5C1" onclick="effectRowCol(4,0)">cell</td>
			<td id="R5C2" onclick="effectRowCol(4,1)">cell</td>
			<td id="R5C3" onclick="effectRowCol(4,2)">cell</td>
			<td id="R5C4" onclick="effectRowCol(4,3)">cell</td>
			<td id="R6C5" onclick="effectRowCol(4,4)">cell</td>
			<td id="R6C6" onclick="effectRowCol(4,5)">cell</td>
			<td id="R6C7" onclick="effectRowCol(4,6)">cell</td>
			<td id="R6C8" onclick="effectRowCol(4,7)">cell</td>
		</tr>
		<tr id="row6">
			<td id="R6C1" onclick="effectRowCol(5,0)">cell</td>
			<td id="R6C2" onclick="effectRowCol(5,1)">cell</td>
			<td id="R6C3" onclick="effectRowCol(5,2)">cell</td>
			<td id="R6C4" onclick="effectRowCol(5,3)">cell</td>
			<td id="R6C5" onclick="effectRowCol(5,4)">cell</td>
			<td id="R6C6" onclick="effectRowCol(5,5)">cell</td>
			<td id="R6C7" onclick="effectRowCol(5,6)">cell</td>
			<td id="R6C8" onclick="effectRowCol(5,7)">cell</td>
		</tr>
		<tr id="row7">
			<td id="R7C1" onclick="effectRowCol(6,0)">cell</td>
			<td id="R7C2" onclick="effectRowCol(6,1)">cell</td>
			<td id="R7C3" onclick="effectRowCol(6,2)">cell</td>
			<td id="R7C4" onclick="effectRowCol(6,3)">cell</td>
			<td id="R7C5" onclick="effectRowCol(6,4)">cell</td>
			<td id="R7C6" onclick="effectRowCol(6,5)">cell</td>
			<td id="R7C7" onclick="effectRowCol(6,6)">cell</td>
			<td id="R7C8" onclick="effectRowCol(6,7)">cell</td>
		</tr>
		<tr id="row8">
			<td id="R8C1" onclick="effectRowCol(7,0)">cell</td>
			<td id="R8C2" onclick="effectRowCol(7,1)">cell</td>
			<td id="R8C3" onclick="effectRowCol(7,2)">cell</td>
			<td id="R8C4" onclick="effectRowCol(7,3)">cell</td>
			<td id="R8C5" onclick="effectRowCol(7,4)">cell</td>
			<td id="R8C6" onclick="effectRowCol(7,5)">cell</td>
			<td id="R8C7" onclick="effectRowCol(7,6)">cell</td>
			<td id="R8C8" onclick="effectRowCol(7,7)">cell</td>
		</tr>
	</table>
<script>
changeNumbers();
</script>
</center>
</br>
<h3> progress bar </h3>
<div id="myProgress">
  <div id="myBar">50%</div>
</div>

<br>
<button onclick="move()">Click Me</button> 

<script>
function move() {
  var elem = document.getElementById("myBar");   
  var width = 10;
  var id = setInterval(frame, 10);
  function frame() {
    if (width >= 100) {
      clearInterval(id);
    } else {
      width++; 
      elem.style.width = width + '%'; 
      elem.innerHTML = width * 1  + '%';
    }
  }
}
</script>
</body>
</html>
