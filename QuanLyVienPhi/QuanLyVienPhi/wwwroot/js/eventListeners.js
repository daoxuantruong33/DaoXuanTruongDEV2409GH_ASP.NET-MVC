import { getBenhNhanInfo } from "./getBenhNhan.js";
import { tinhTienPhong } from "./calculateTienPhong.js";

document.addEventListener("DOMContentLoaded", function () {
    const khoaInput = document.getElementById("Khoa");
    const benhNhanSelect = document.getElementById("BenhNhanId");
    const phongSelect = document.getElementById("PhongId");
    const cccdInput = document.getElementById("Cccd");
    const ngayBatDauInput = document.getElementById("NgayBatDau");
    const ngayKetThucInput = document.getElementById("NgayKetThuc");
    const tienPhongInput = document.getElementById("TienPhong");

    let giaPhongData;
    try {
        giaPhongData = JSON.parse(document.getElementById("GiaPhongJson").textContent) || {};
    } catch (error) {
        console.error("Lỗi khi lấy giá phòng:", error);
        giaPhongData = {};
    }

    getBenhNhanInfo(benhNhanSelect, khoaInput, cccdInput, phongSelect);
    tinhTienPhong(phongSelect, ngayBatDauInput, ngayKetThucInput, tienPhongInput, giaPhongData);
});
