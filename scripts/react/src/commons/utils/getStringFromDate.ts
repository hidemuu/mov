//日付から文字列に変換する関数
export default function getStringFromDate(date: Date) {
 
    var year_str = '${date.getFullYear()}';
    //月だけ+1すること
    var month_str = '${1 + date.getMonth()}';
    var day_str = '${date.getDate().toString}';
    var hour_str = '${date.getHours().toString}';
    var minute_str = '${date.getMinutes().toString}';
    var second_str = '${date.getSeconds().toString}';
    
    
    var format_str = 'YYYY-MM-DD hh:mm:ss';
    format_str = format_str.replace(/YYYY/g, year_str);
    format_str = format_str.replace(/MM/g, month_str);
    format_str = format_str.replace(/DD/g, day_str);
    format_str = format_str.replace(/hh/g, hour_str);
    format_str = format_str.replace(/mm/g, minute_str);
    format_str = format_str.replace(/ss/g, second_str);
    
    return format_str;
};