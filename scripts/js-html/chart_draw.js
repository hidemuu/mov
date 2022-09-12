$(() => {
//---- パラメータ ----------
const chartFileName = 'chart_item.json', configFileName = 'chart_config.json';

//---- Canvas描画 ---------
function drawChart(data, configs) {
	console.log(data);
//データ成形
//	ラベル（項目はひとつ）
//	データ系列の数だけ設定
	let chartLabels = [], chartData = [];
	for(let row in data) {
		const item = data[row], dataItem = item[1];
		chartLabels.push(item[0]);
		while(chartData.length < dataItem.length) { chartData.push([]); }
//データ系列の数だけ設定
		for(let i = 0; i < dataItem.length; i++) { chartData[i].push(dataItem[i]); }
	};
	console.log('--- chartLabels -----');
	console.log(chartLabels);
	console.log('--- chartData -----');
	console.log(chartData);

//コンフィグ成形
	let chartIds = [], chartTitles = [], chartTypes = [], chartBackgroundColors = [], chartBorderColors = [], chartBorderWidthes = [];

	for(let row in configs) {
		const config = configs[row];
		chartIds.push(config[0]);
		chartTitles.push(config[1]);
		chartTypes.push(config[2]);
		chartBackgroundColors.push(config[3]);
		chartBorderColors.push(config[4]);
		chartBorderWidthes.push(config[5]);
	}
	console.log('--- chartConfig -----');
	console.log(chartIds);
	console.log(chartTitles);
	console.log(chartTypes);
	console.log(chartBackgroundColors);
	console.log(chartBorderColors);
	console.log(chartBorderWidthes);

//ブラウザ更新
	if(window.name != "chart") {
//		alert("リロードしました");
		window.location.reload();
		window.name = "chart";
	} else {
		window.name = "";
	}

//Canvas描画
	const myChart = new Chart($('#myChart')[0].getContext('2d'), {
		type: chartTypes[0],
		data: {
			labels: chartLabels,
			datasets: [
				{
					label: chartTitles[0],
					data: chartData[0],
					borderColor: chartBorderColors[0],
					backgroundColor: chartBackgroundColors[0],
					borderWidth: chartBorderWidthes[0]
				},
				{
					label: chartTitles[1],
					data: chartData[1],
					borderColor: chartBorderColors[1],
					backgroundColor: chartBackgroundColors[1],
					borderWidth: chartBorderWidthes[1]
				},
				{
					label: chartTitles[2],
					data: chartData[2],
					borderColor: chartBorderColors[2],
					backgroundColor: chartBackgroundColors[2],
					borderWidth: chartBorderWidthes[2]
				},
				{
					label: chartTitles[3],
					data: chartData[3],
					borderColor: chartBorderColors[3],
					backgroundColor: chartBackgroundColors[3],
					borderWidth: chartBorderWidthes[3]
				}
			]//データ系列の数だけ準備
		},
		options: {
//			responsive: true,
//			maintainAspectRatio: false,
			legend: {
//				display: false
			},
			title: {
				display: true,
				text: 'title'
			},
			scales: {
				yAxes: [
					{
						ticks: {
							suggestedMax: 40,
							suggestedMin: 0,
							stepSize: 10,
							callback: (value, index, values) => { return value + ''; }
						}
					}
				]
			}
		}
	});
}

function getChartData(dt) {
	console.log("--- keyデータ ---");
	const keys = Object.keys(dt[0]);
	console.log(keys);
	let result = [];
	for(let row in dt) {
		const item = dt[row];
		let unit = [];
//ラベルデータ格納
		unit.push(item['date']);//{"data":["1324","123","5564"],"date":"2020/1/14"}  title:[0:"data",1:"date"] data[0,1,2…]["date"]
//チャートデータ格納
		for(let col in keys) {//data[row].data==["1324","123","5564"] data[row].date
			const key = keys[col];
			if(key != 'data') { continue; }//"date"
//配列かどうかで分岐 配列ならforで詰め込む
			if(Array.isArray(item[key])) { for(let v in item[key]) { unit.push(item[key][v]); } }
			else if(item[key].indexOf(',') >= 0) { unit.push(item[key].split(',')); }
			else { unit.push(item[key]); }//title[col] == "data"
		}
		result.push(unit);//["2020/2/14","1","0","1","54"]
	}
	console.log('--- chartアイテム ---');
	console.log(result);
	return result;
}

function getConfigData(fileName) {
	let result = [];
	$.getJSON(fileName).done(data => {// 成功時処理
		console.log("getConfig - getJSON成功");
		console.log("--- JSONデータ ---");
		console.log(data);
		console.log("--- keyデータ ---");
		const keys = Object.keys(data[0]);
		console.log(keys);
		for(let row in data) {
			const item = data[row];
			result.push([
				item['id'],
				item['name'],
				item['chart_type'],
				item['background_color'],
				item['border_color'],
				item['border_width']
			]);//["id","name","type","color",…]
		}
		console.log('--- chartConfig ---');
		console.log(result);
	}).fail((jqXHR, textStatus, errorThrown) => {// 失敗時処理
		console.log("getConfig - getJSON失敗");
		console.log("jqXHR : " + jqXHR.status);// httpステータス
		console.log("textStatus : " + textStatus);// タイムアウト、パースエラー
		console.log("errorThrown : " + errorThrown.message);// エラーの詳細情報
	}).always(() => {// 常時実行処理

	});
	return result;
}

//----- 主幹シーケンス --------
function main_json(fileName, configs) {
	$.getJSON(fileName).done(data => {// 成功時処理
		console.log("getChart - getJSON成功");
		console.log("--- JSONデータ ---");
		console.log(data);
		drawChart(getChartData(data), configs);
	}).fail((jqXHR, textStatus, errorThrown) => {// 失敗時処理
		console.log("getChart - getJSON失敗");
		console.log("jqXHR : " + jqXHR.status);// httpステータス
		console.log("textStatus : " + textStatus);// タイムアウト、パースエラー
		console.log("errorThrown : " + errorThrown.message);// エラーの詳細情報
	}).always(() => {// 常時実行処理

	});
}

function main_csv(fileName, configs) {
	const req = new XMLHttpRequest();
	req.open('GET', fileName, true);
	req.onload = () => {
		const lines = req.responseText.replace('\r\n', '\n').replace('\r', '\n').split('\n');
		let csvData = [];
		for(let row in lines) { csvData.push(lines[row].split(',')); }
		drawChart(csvData, configs);
	};
	req.send(null);
};

function main_file(configs) {
	$('#myfile').on('change', e => {
// 読み込んだファイル情報を取得
		const result = e.target.files[0], reader = new FileReader();
		console.log(result);
		reader.readAsText(result);// 読み込んだファイルの中身を取得する
// ファイルの中身を取得後に処理を行う
		reader.addEventListener('load', () => {
			$('#output').text(reader.result);
			drawChart(getChartData(JSON.parse(reader.result)), configs);
		});
	});
}

function main() {
	console.log('running...');
//グラフコンフィグ取得
	const configs = getConfigData(configFileName);
//Canvas描画
	if(chartFileName.includes('.json')) { main_json(chartFileName, configs); }
	else if(chartFileName.includes('.csv')) { main_csv(chartFileName, configs); }
	else if(chartFileName == '') { main_file(configs); }
	else { console.log('対応していないファイル形式が指定されています [json/csv/]'); }
}

//---- メインスクリプト ------------
main();
});
