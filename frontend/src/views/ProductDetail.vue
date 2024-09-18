<template>
    <div class="flex flex-col ">
        <div class="flex flex-wrap gap-2 items-center text-xs md:text-sm px-5 md:px-10 py-2 bg-gray-100 text-gray-500">
            <a href="/">Trang chủ </a>/<a href=""> Tất cả sản phẩm MOHO</a>/<p class="line-clamp-1">Hệ tủ bếp MOHO Kitchen Premium Ubeda Nhiều Kích Thước</p>
        </div>
        <div class="flex flex-col gap-5 p-5 md:p-10">
            <div class="grid grid-cols-1 md:grid-cols-2 gap-5">
                <div class="relative">
                    <div class="w-full flex flex-col gap-2 sticky top-1">
                    <img src="/assets/image/New/new1.webp" alt="" class="max-w-full h-auto">
                    <div class="flex flex-wrap gap-3">
                        <img src="/assets/image/New/new1.webp" alt="" class="w-14 h-14">
                        <img src="/assets/image/New/new1.webp" alt="" class="w-14 h-14">
                        <img src="/assets/image/New/new1.webp" alt="" class="w-14 h-14">

                    </div>
                </div>
                </div>
                <div class="relative flex flex-col">
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
            <div class="flex flex-col w-full border">
                <div class="w-full h-auto bg-gray-100 flex items-center">
                    <div @click="CurrentTab = 'tab1'" :class="{'bg-gray-300': CurrentTab === 'tab1'}" class="p-2 hover:bg-gray-200 cursor-pointer">Mô tả</div>
                    <div @click="CurrentTab = 'tab2'" :class="{'bg-gray-300': CurrentTab === 'tab2'}" class="p-2 hover:bg-gray-200 cursor-pointer">Đánh giá (67)</div>
                    <div @click="CurrentTab = 'tab3'" :class="{'bg-gray-300': CurrentTab === 'tab3'}" class="p-2 hover:bg-gray-200 cursor-pointer">Chính sách</div>
                </div>
                <div v-if="CurrentTab === 'tab1'" class="flex p-2">
                    <p class="text-sm text-gray-500">Bàn làm việc văn phòng chân trắng mặt gỗ được làm bằng chất liệu gỗ công nghiệp cao cấp. Trên mặt bàn được phủ một lớp Melamine, sơn PU chống trầy xước tốt, ẩm mốc, bóng đẹp theo thời gian. Với độ dày 18mm hoặc có thể là 25mm theo yêu cầu riêng của khách. Bàn có thiết kế dạng thẳng mặt bàn vuông vức. Bàn có 4 chân được làm bằng khung sắt khi kê bàn ở bất kỳ mặt bằng nào.</p>
                </div>
                <div v-if="CurrentTab === 'tab2'"  class="flex w-full p-2">
                    <div class="flex flex-col gap-2 w-full">
                        <div class="flex items-center">
                            <VueIcon v-for="i in 5" :key="i" type="mdi" :path="mdiStar" size="20"/>
                            (5.0)
                        </div>
                        <div class="flex flex-col gap-2">
                            <div class="flex items-center gap-5">
                                <h1 class="font-bold">Viết đánh giá</h1>
                                <select name="" id="" class="border-2 w-40 p-1">
                                    <option value="">1sao</option>
                                    <option value="">2sao</option>
                                    <option value="">3sao</option>
                                    <option value="">4sao</option>
                                    <option value="">5sao</option>
                                </select>
                            </div>
                            <textarea class="border outline-none p-2" placeholder="Viết gì đó ..."/>
                            <div class="flex bottom-2 overflow-x-auto justify-between">
                                <div class=" flex flex-wrap">
                                    <label for="file" class="w-10 h-10 md:w-20 md:h-20 border-2 flex justify-center items-center hover:cursor-pointer"><VueIcon type="mdi" :path="mdiCamera" class=""/></label>
                                    <div v-if="image" class="flex">
                                        <div v-for="(img,index) in image" :key="index" class="relative">
                                            <img :src="img" alt="" class="w-10 h-10 md:w-20 md:h-20 border-2 text-2xl block hover:cursor-pointer">
                                            <VueIcon type="mdi" :path="mdiClose" @click="remove(index)" class="absolute top-0 right-0 p-1 hover:cursor-pointer border bg-slate-100 rounded-[50%]"/>
                                        </div>
                                    </div>
                                </div>
                                <input type="file" hidden id="file" name="image" @change="handleImageChange">
                                <button type="button" class="p-2 border bg-blue-500 text-white self-center rounded-sm">Send</button>
                            </div>
                        </div>
                        <div class=' mt-3 border-4 border-black h-[105vh] p-2 relative'>
                            <h1 class="text-sm md:text-base">Bình luận (10)</h1>
                            <div class="h-[90vh] overflow-y-auto">
                                <div class='border-b'>
                                <div class='flex mt-3 items-center gap-3'>
                                    <div class="border w-10 h-10 rounded-[50%]" >
                                        <img src="/assets/image/New/new1.webp" alt="" class='rounded-[50%]'/> 
                                    </div>
                                    <div class=' flex flex-col'>
                                        <p class="text-sm md:text-md">Dat Nguyen</p>
                                        <div class="flex">
                                            <VueIcon v-for="i in 5" :key="i" type="mdi" :path="mdiStar" size="15" class=" text-yellow-300"/>
                                        </div>
                                        <p class="text-[10px]">11-11-2024</p>
                                    </div>
                                </div>
                                <div class='my-2 px-2'>
                                    <span class="text-xs sm:text-base">qua tuyet voi</span>
                                    <div class="flex gap-3">
                                        <img v-for="src in image" :key="src" :src="src" class="w-10 h-10 sm:w-20 sm:h-20">
                                    </div>
                                </div>
                            </div>
                            </div>
                            <button class="w-full text-center bg-[#271511] text-white leading-8">Xem thêm bình luận (10)</button>
                        </div>
                    </div>
                </div>
                <div v-if="CurrentTab === 'tab3'"  class="flex p-2 flex-col gap-2">
                    <h1>Xem chi tiết các chính sách tại: </h1>
                    <ol class="text-blue-800">
                        <li><a href=""><b>- Khách Hàng Thân Thiết - MOHOhomie</b></a></li>
                        <li><a href=""><b>- Review Hay Nhận Quà Ngay - MOHOment</b></a></li>
                        <li><a href=""><b>- Chính Sách Bán Hàng</b></a></li>
                        <li><a href=""><b>- Chính sách Giao Hàng & Lắp Đặt</b></a></li>
                        <li><a href=""><b>- Chính Sách Đổi Trả</b></a></li>
                        <li><a href=""><b>- Chính Sách Bảo Hành - Bảo Trì</b></a></li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import { mdiFacebook, mdiStar,mdiCheck, mdiClose, mdiCamera } from '@mdi/js';

export default {
    name:"ProductDetail",
    data(){
        return{
            mdiStar,mdiFacebook,mdiCheck,mdiClose,mdiCamera,
            image:[],
            CurrentTab:'tab1'
        }
    },
    mounted(){
        console.log(this.CurrentTab)
    },
    methods:{
        remove(index) {
            this.image.splice(index, 1); 
            
        },
        async handleImageChange(event) {
            const file = event.target.files[0];
            this.image.push(file.name);
        }
    }
}
</script>