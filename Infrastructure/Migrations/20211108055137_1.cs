using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaDiem",
                columns: table => new
                {
                    MaDiaDiem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaDiem", x => x.MaDiaDiem);
                });

            migrationBuilder.CreateTable(
                name: "Khach",
                columns: table => new
                {
                    MaKhachHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoCMND = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuocTich = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khach", x => x.MaKhachHang);
                });

            migrationBuilder.CreateTable(
                name: "LoaiChiPhi",
                columns: table => new
                {
                    MaLoaiChiPhi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiChiPhi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiChiPhi", x => x.MaLoaiChiPhi);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHinhDuLich",
                columns: table => new
                {
                    MaLoaiHinh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiHinh = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHinhDuLich", x => x.MaLoaiHinh);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNhanVien);
                });

            migrationBuilder.CreateTable(
                name: "TourDuLich",
                columns: table => new
                {
                    MaTour = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenGoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DacDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoaiHinh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourDuLich", x => x.MaTour);
                    table.ForeignKey(
                        name: "FK_TourDuLich_LoaiHinhDuLich_MaLoaiHinh",
                        column: x => x.MaLoaiHinh,
                        principalTable: "LoaiHinhDuLich",
                        principalColumn: "MaLoaiHinh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiemThamQuan",
                columns: table => new
                {
                    MaTour = table.Column<int>(type: "int", nullable: false),
                    MaDiaDiem = table.Column<int>(type: "int", nullable: false),
                    ThuTu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemThamQuan", x => new { x.MaDiaDiem, x.MaTour });
                    table.ForeignKey(
                        name: "FK_DiemThamQuan_DiaDiem_MaDiaDiem",
                        column: x => x.MaDiaDiem,
                        principalTable: "DiaDiem",
                        principalColumn: "MaDiaDiem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiemThamQuan_TourDuLich_MaTour",
                        column: x => x.MaTour,
                        principalTable: "TourDuLich",
                        principalColumn: "MaTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoanDuLich",
                columns: table => new
                {
                    MaDoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTour = table.Column<int>(type: "int", nullable: false),
                    TenDoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayKhoiHanh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoanhThu = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanDuLich", x => x.MaDoan);
                    table.ForeignKey(
                        name: "FK_DoanDuLich_TourDuLich_MaTour",
                        column: x => x.MaTour,
                        principalTable: "TourDuLich",
                        principalColumn: "MaTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GiaTour",
                columns: table => new
                {
                    MaGia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTour = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<long>(type: "bigint", nullable: false),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaTour", x => x.MaGia);
                    table.ForeignKey(
                        name: "FK_GiaTour_TourDuLich_MaTour",
                        column: x => x.MaTour,
                        principalTable: "TourDuLich",
                        principalColumn: "MaTour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiPhi",
                columns: table => new
                {
                    MaChiPhi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDoan = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<long>(type: "bigint", nullable: false),
                    MaLoaiChiPhi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiPhi", x => x.MaChiPhi);
                    table.ForeignKey(
                        name: "FK_ChiPhi_DoanDuLich_MaDoan",
                        column: x => x.MaDoan,
                        principalTable: "DoanDuLich",
                        principalColumn: "MaDoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiPhi_LoaiChiPhi_MaLoaiChiPhi",
                        column: x => x.MaLoaiChiPhi,
                        principalTable: "LoaiChiPhi",
                        principalColumn: "MaLoaiChiPhi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDoan",
                columns: table => new
                {
                    MaDoan = table.Column<int>(type: "int", nullable: false),
                    MaKhachHang = table.Column<int>(type: "int", nullable: false),
                    VaiTro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDoan", x => new { x.MaDoan, x.MaKhachHang });
                    table.ForeignKey(
                        name: "FK_ChiTietDoan_DoanDuLich_MaDoan",
                        column: x => x.MaDoan,
                        principalTable: "DoanDuLich",
                        principalColumn: "MaDoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDoan_Khach_MaKhachHang",
                        column: x => x.MaKhachHang,
                        principalTable: "Khach",
                        principalColumn: "MaKhachHang",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoiDungTour",
                columns: table => new
                {
                    MaDoan = table.Column<int>(type: "int", nullable: false),
                    HanhTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhachSan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaDiemThamQuan = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiDungTour", x => x.MaDoan);
                    table.ForeignKey(
                        name: "FK_NoiDungTour_DoanDuLich_MaDoan",
                        column: x => x.MaDoan,
                        principalTable: "DoanDuLich",
                        principalColumn: "MaDoan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhanBoNhanVien_Doan",
                columns: table => new
                {
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaDoan = table.Column<int>(type: "int", nullable: false),
                    NhiemVu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanBoNhanVien_Doan", x => new { x.MaDoan, x.MaNhanVien });
                    table.ForeignKey(
                        name: "FK_PhanBoNhanVien_Doan_DoanDuLich_MaDoan",
                        column: x => x.MaDoan,
                        principalTable: "DoanDuLich",
                        principalColumn: "MaDoan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanBoNhanVien_Doan_NhanVien_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NhanVien",
                        principalColumn: "MaNhanVien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiPhi_MaDoan",
                table: "ChiPhi",
                column: "MaDoan");

            migrationBuilder.CreateIndex(
                name: "IX_ChiPhi_MaLoaiChiPhi",
                table: "ChiPhi",
                column: "MaLoaiChiPhi");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDoan_MaKhachHang",
                table: "ChiTietDoan",
                column: "MaKhachHang");

            migrationBuilder.CreateIndex(
                name: "IX_DiemThamQuan_MaTour",
                table: "DiemThamQuan",
                column: "MaTour");

            migrationBuilder.CreateIndex(
                name: "IX_DoanDuLich_MaTour",
                table: "DoanDuLich",
                column: "MaTour");

            migrationBuilder.CreateIndex(
                name: "IX_GiaTour_MaTour",
                table: "GiaTour",
                column: "MaTour");

            migrationBuilder.CreateIndex(
                name: "IX_PhanBoNhanVien_Doan_MaNhanVien",
                table: "PhanBoNhanVien_Doan",
                column: "MaNhanVien");

            migrationBuilder.CreateIndex(
                name: "IX_TourDuLich_MaLoaiHinh",
                table: "TourDuLich",
                column: "MaLoaiHinh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiPhi");

            migrationBuilder.DropTable(
                name: "ChiTietDoan");

            migrationBuilder.DropTable(
                name: "DiemThamQuan");

            migrationBuilder.DropTable(
                name: "GiaTour");

            migrationBuilder.DropTable(
                name: "NoiDungTour");

            migrationBuilder.DropTable(
                name: "PhanBoNhanVien_Doan");

            migrationBuilder.DropTable(
                name: "LoaiChiPhi");

            migrationBuilder.DropTable(
                name: "Khach");

            migrationBuilder.DropTable(
                name: "DiaDiem");

            migrationBuilder.DropTable(
                name: "DoanDuLich");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "TourDuLich");

            migrationBuilder.DropTable(
                name: "LoaiHinhDuLich");
        }
    }
}
