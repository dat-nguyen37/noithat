<template>
    <div class="flex flex-col ">
        <div class="flex gap-2 items-center px-5 md:px-10 h-10 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/<a href=""> Tất cả sản phẩm MOHO</a>/<p>Hệ tủ bếp MOHO Kitchen Premium Ubeda Nhiều Kích Thước</p>
        </div>
        <div class="flex flex-col p-5 md:p-10">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
                <div>
                    <img src="/assets/image/New/new1.webp" alt="">
                </div>
                <div class="flex flex-col">
                    <h1 class="text-xl font-bold">Hệ tủ bếp MOHO Kitchen Premium Ubeda Nhiều Kích Thước</h1>
                    <div class="flex flex-col">
                        <div class="flex justify-between border-b pb-5">
                            <div class="flex items-center">
                                <VueIcon v-for="i in 5" :key="i" type="mdi" :path="mdiStar" size="20"/> (1)
                            </div>
                            <div class="flex gap-5 items-center">
                                <div class="flex gap-2">
                                    <p>Chia sẻ:</p>
                                    <VueIcon type="mdi" :path="mdiFacebook" size="30" class="text-blue-500 "/>
                                </div>
                                <p>Đã bán: 1</p>
                            </div>
                        </div>
                        <div class="flex items-center gap-3 py-2 text-center border-b">
                            <div class="w-16 py-1 font-bold bg-gray-100 text-red-500">-40%</div>
                            <p class="font-bold text-red-500">11,890,000₫</p>
                            <s class="">19,816,667 <u>đ</u></s>
                        </div>
                        <div class="flex items-center flex-wrap gap-3 py-2 text-center border-b text-sm">
                            <div class="w-20 h-10 border flex justify-center items-center">1m5 chữ I</div>
                            <div class="w-20 h-10 border flex justify-center items-center">2m3 chữ I</div>
                            <div class="w-20 h-10 border flex justify-center items-center">2m7 chữ I</div>    
                            <div class="w-20 h-10 border flex justify-center items-center">2m6 chữ L</div>
                            <div class="w-20 h-10 border flex justify-center items-center">3m4 chữ L</div>
                        </div>
                        <div class="flex flex-col gap-3">
                            <b class="flex gap-2 text-red-500">Bảo hành: <p class="text-black">2 năm</p></b>
                            <i><u><b>Lưu ý: </b></u>Sản phẩm hiện chỉ được cung cấp tại khu vực Thành phố Hồ Chí Minh.</i>
                            <div class="w-full bg-blue-800 text-center text-xl uppercase py-2 text-white font-bold">Hãy để MOho tư vấn cho bạn trước khi đặt hàng</div>
                            <p class="">Nhắn tin Fanpage: <a href=""><b class="text-white bg-blue-800 p-2">Nội thất moho</b></a></p>
                            <p class="">Gọi ngay Hotline:  <b class=" text-blue-800 p-2">0966544325(Zalo)</b></p>
                            <div class="flex border w-32 h-8 font-bold text-xl text-center items-center">
                                <div class="bg-gray-100 w-8 cursor-pointer">-</div>
                                <input type="text" class="w-16 text-center outline-none" value="1">
                                <div class="bg-gray-100 w-8 cursor-pointer">+</div>
                            </div>
                            <button class="font-bold text-white text-xl py-2 uppercase bg-blue-800">Thêm vào giỏ</button>
                            <button class="font-bold text-white text-xl py-2 uppercase bg-red-500">Mua ngay</button>
                            <p class="text-sm text-gray-500">(+) Miễn phí giao hàng & lắp đặt tại tất cả quận huyện thuộc TP.HCM, Hà Nội, Khu đô thị Ecopark, Biên Hòa và một số quận thuộc Bình Dương (*)</p>
                            <p class="text-sm text-gray-500">(+) Miễn phí 1 đổi 1 - Bảo hành 2 năm - Bảo trì trọn đời (**)</p>
                            <p class="text-sm text-gray-500">(*) Không áp dụng cho danh mục Đồ Trang Trí</p>
                            <p class="text-sm text-gray-500">(**) Không áp dụng cho các sản phẩm Clearance. Chỉ bảo hành 01 năm cho khung ghế, mâm và cần đối với Ghế Văn Phòng</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mdiFacebook, mdiStar,mdiCheck } from '@mdi/js';

export default {
    name:"ProductDetail",
    data(){
        return{
            mdiStar,mdiFacebook,mdiCheck
        }
    }
}
</script>