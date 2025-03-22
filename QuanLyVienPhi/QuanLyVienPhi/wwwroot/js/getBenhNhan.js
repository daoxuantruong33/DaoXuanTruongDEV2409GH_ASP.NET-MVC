export function getBenhNhanInfo(benhNhanSelect, khoaInput, cccdInput, phongSelect) {
    benhNhanSelect.addEventListener("change", function () {
        const benhNhanId = benhNhanSelect.value;
        if (benhNhanId) {
            fetch(`/Admins/ChiTietPhongs/GetThongTinBenhNhan?benhNhanId=${benhNhanId}`)
                .then(response => response.json())
                .then(data => {
                    if (data) {
                        khoaInput.value = data.khoa || "Chưa cập nhật";
                        cccdInput.value = data.cccd || "";

                        fetch(`/Admins/ChiTietPhongs/GetPhongByKhoa?khoaId=${data.khoaId}`)
                            .then(response => response.json())
                            .then(phongList => {
                                phongSelect.innerHTML = "<option value=''>Chọn phòng</option>";
                                phongList.forEach(phong => {
                                    const option = document.createElement("option");
                                    option.value = phong.phongId;
                                    option.textContent = phong.soPhong;
                                    phongSelect.appendChild(option);
                                });
                            })
                            .catch(error => console.error("Lỗi khi lấy danh sách phòng:", error));
                    }
                })
                .catch(error => console.error("Lỗi lấy thông tin bệnh nhân:", error));
        } else {
            khoaInput.value = "";
            cccdInput.value = "";
            phongSelect.innerHTML = "<option value=''>Chọn phòng</option>";
        }
    });
}
