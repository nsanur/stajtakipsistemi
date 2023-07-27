$(function(){
    $('#tblStajyerler').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.12/i18n/Turkish.json"
        }
    });

    $("#tblStajyerler").on("click", ".btnStajyerSil", function () {

        var btn = $(this);
        bootbox.confirm("Silmek istediğinizden emin misiniz?", function (result) { 
            
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Stajyer/Sil/" + id,
                    
                    success: function () {

                        //console.log("başarılı..");
                        btn.parent().parent().remove();
                    }
                });

            }

        })       
    });
});