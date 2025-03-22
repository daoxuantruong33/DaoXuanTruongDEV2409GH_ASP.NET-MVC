export function tinhTienPhong(phongSelect, ngayBatDauInput, ngayKetThucInput, tienPhongInput, giaPhongData) {
    function calculate() {
        const phongId = phongSelect.value;
        const giaPhong = giaPhongData[phongId] ? parseFloat(giaPhongData[phongId]) : 0;

        const ngayBatDau = new Date(ngayBatDauInput.value);
        const ngayKetThuc = new Date(ngayKetThucInput.value);

        if (!isNaN(ngayBatDau.getTime()) && !isNaN(ngayKetThuc.getTime()) && ngayBatDau <= ngayKetThuc) {
            const soNgay = Math.ceil((ngayKetThuc - ngayBatDau) / (1000 * 60 * 60 * 24));
            const tongTien = soNgay * giaPhong;
            tienPhongInput.value = tongTien.toLocaleString("vi-VN");
        } else {
            tienPhongInput.value = "";
        }
    }

    phongSelect.addEventListener("change", calculate);
    ngayBatDauInput.addEventListener("change", calculate);
    ngayKetThucInput.addEventListener("input", calculate);
}
