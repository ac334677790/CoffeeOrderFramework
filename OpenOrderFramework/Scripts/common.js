$(function () {
        //自訂長度
        $("input[data-val-length-max]").each(function (index, element) {
            var length = parseInt($(this).attr("data-val-length-max"));
            $(this).prop("maxlength", length);
        });

    //必填欄位
        $.each($('input , select'), function (index, value) {
            if (typeof ($('#' + value.id).attr('data-val-required')) !== 'undefined' && value.id != 'Email' && value.id != 'Password' && value.type != 'hidden')
            {
                //alert(value.id);
                var label = $('#' + value.id).parent().parent().find('label');
                label.text('*' + label.text()).css({'color':'red'});

            }
        });

        //$("[data-toggle='toggle']").bootstrapToggle({
        //    on: '開',
        //    off: '關',
        //    size: 'mini'
    //});

        $('.fancybox').fancybox({ 'width': "80%" });

        $('.datetimepicker').datetimepicker({
            locale: 'zh-tw',
            format: 'YYYY/MM/DD HH:mm'
        });
});

//參數1 str：需要補0的字串
//參數2 len：要補0的長度
// 左邊補0
function padLeft(str,lenght){
    if(str.length >= lenght)
        return str;
    else
        return padLeft("0" +str,lenght);
}
 

//右邊補0
function padRight(str,lenght){
    if(str.length >= lenght)
        return str;
    else
        return padRight(str+"0",lenght);
}

//當日
function getToday() {
    return new Date().getFullYear() + '-' + padLeft((new Date().getMonth() + 1), 2) + '-' + padLeft((new Date().getDate() + 1), 2);
}

//當日
function getEndDay() {
    return new '2999-12-31';
}

