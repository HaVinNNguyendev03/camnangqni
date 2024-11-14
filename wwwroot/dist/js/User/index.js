datatable =  new DataTable('#myTable', {
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv',
        {
            extend: 'excel',
            customize: function ( xlsx ){
                
            }
        },  
        'pdf', 'print'
    ],
    language : {
        "sProcessing": "Đang xử lý...",
        "sLengthMenu": "Hiển thị _MENU_ mục",
        "sZeroRecords": "Không tìm thấy dòng nào phù hợp",
        "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
        "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số 0 mục",
        "sInfoFiltered": "(được lọc từ _MAX_ mục)",
        "sInfoPostFix": "",
        "sSearch": "Tìm kiếm:",
        "sUrl": "",
        "oPaginate": {
            "sFirst": "Đầu",
            "sPrevious": "Trước",
            "sNext": "Tiếp",
            "sLast": "Cuối"
        },
        "oAria": {
            "sSortAscending": ": Kích hoạt để sắp xếp cột tăng dần",
            "sSortDescending": ": Kích hoạt để sắp xếp cột giảm dần"
        }
    }
    });