// ** I18N

// Calendar EN language
// Author: Mihai Bazon, <mihai_bazon@yahoo.com>
// Encoding: any
// Distributed under the same terms as the calendar itself.

// For translators: please use UTF-8 if possible.  We strongly believe that
// Unicode is the answer to a real internationalized world.  Also please
// include your contact information in the header, as can be seen above.

// full day names
Calendar._DN = new Array
("Chủ nhật",
 "Thứ hai",
 "Thứ ba",
 "Thứ tư",
 "Thứ năm",
 "Thứ sáu",
 "Thứ bảy",
 "Chủ nhật");

// Please note that the following array of short day names (and the same goes
// for short month names, _SMN) isn't absolutely necessary.  We give it here
// for exemplification on how one can customize the short day names, but if
// they are simply the first N letters of the full name you can simply say:
//
//   Calendar._SDN_len = N; // short day name length
//   Calendar._SMN_len = N; // short month name length
//
// If N = 3 then this is not needed either since we assume a value of 3 if not
// present, to be compatible with translation files that were written before
// this feature.

// short day names
Calendar._SDN = new Array
("CN",
 "Hai",
 "Ba",
 "Tư",
 "Năm",
 "Sáu",
 "Bảy",
 "CN");

// First day of the week. "0" means display Sunday first, "1" means display
// Monday first, etc.
Calendar._FD = 0;

// full month names
Calendar._MN = new Array
("Tháng Một",
 "Tháng Hai",
 "Tháng Ba",
 "Tháng Tư",
 "Tháng Năm",
 "Tháng Sáu",
 "Tháng Bảy",
 "Tháng Tám",
 "Tháng Chín",
 "Tháng Mười",
 "Tháng Mười Một",
 "Tháng Mười Hai");

// short month names
Calendar._SMN = new Array
("Tháng 1",
 "Tháng 2",
 "Tháng 3",
 "Tháng 4",
 "Tháng 5",
 "Tháng 6",
 "Tháng 7",
 "Tháng 8",
 "Tháng 9",
 "Tháng 10",
 "Tháng 11",
 "Tháng 12");

// tooltips
Calendar._TT = {};
Calendar._TT["INFO"] = "Giới thiệu";

Calendar._TT["ABOUT"] =
"DHTML Date/Time Selector\n" +
"(c) dynarch.com 2002-2005 / Tác giả: Mihai Bazon\n" + // don't translate this this ;-)
"Phiên bản cuối cùng có thể xem tại: http://www.dynarch.com/projects/calendar/\n" +
"Phân phối dưới giấy phép sử dụng GNU LGPL.  Xem thêm chi tiết ở http://gnu.org/licenses/lgpl.html." +
"\n\n" +
"Chọn ngày:\n" +
"- Sử dụng các nút \xab, \xbb để chọn năm\n" +
"- Sử dụng các nút " + String.fromCharCode(0x2039) + ", " + String.fromCharCode(0x203a) + " để chọn tháng\n" +
"- Giữ nút chuột trên bất kỳ nút nào ở trên để chọn nhanh hơn.";
Calendar._TT["ABOUT_TIME"] = "\n\n" +
"Chọn giờ:\n" +
"- Click chuột trên bất kỳ thành phần nào của giờ để tăng giá trị\n" +
"- hoặc Shift-click để giảm giá trị\n" +
"- hoặc nhấp giữ chuột và kéo qua lại để chọn nhanh hơn.";

Calendar._TT["PREV_YEAR"] = "Năm trước(Giữ để mở thực đơn)";
Calendar._TT["PREV_MONTH"] = "Tháng trước (Giữ để mở thực đơn)";
Calendar._TT["GO_TODAY"] = "Nhảy tới Hôm nay";
Calendar._TT["NEXT_MONTH"] = "Tháng tới (Giữ để mở thực đơn)";
Calendar._TT["NEXT_YEAR"] = "Năm tới (Giữ để mở thực đơn)";
Calendar._TT["SEL_DATE"] = "Chọn ngày";
Calendar._TT["DRAG_TO_MOVE"] = "Kéo để di chuyển";
Calendar._TT["PART_TODAY"] = " (hôm nay)";

// the following is to inform that "%s" is to be the first day of week
// %s will be replaced with the day name.
Calendar._TT["DAY_FIRST"] = "Hiển thị %s trước tiên";

// This may be locale-dependent.  It specifies the week-end days, as an array
// of comma-separated numbers.  The numbers are from 0 to 6: 0 means Sunday, 1
// means Monday, etc.
Calendar._TT["WEEKEND"] = "0,6";

Calendar._TT["CLOSE"] = "Đóng";
Calendar._TT["TODAY"] = "Hôm nay";
Calendar._TT["TIME_PART"] = "(Shift-)Click hoặc kéo để thay đổi giá trị";

// date formats
Calendar._TT["DEF_DATE_FORMAT"] = "%d-%m-%Y";
Calendar._TT["TT_DATE_FORMAT"] = "%A ngày %e %b năm %Y";

Calendar._TT["WK"] = "Tuần";
Calendar._TT["TIME"] = "Thời gian:";