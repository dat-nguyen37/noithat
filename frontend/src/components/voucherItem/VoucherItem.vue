<template>
    <div class="grid grid-cols-6 max-h-20 bg-yellow-200 rounded-lg">
        <div class="col-span-2 flex justify-center items-center w-full  relative overflow-hidden">
            <div class=" absolute w-4 h-4 rounded-full -top-2 -right-2 bg-white"></div>
            <div class=" absolute w-4 h-4 rounded-full -bottom-2 -right-2 bg-white"></div>
            <div class="rounded-md w-16 h-16">
                <img src="https://theme.hstatic.net/200000796751/1001266995/14/home_coupon_1_img.png?v=38" alt="" class="w-full h-full object-fill">
            </div>
        </div> 
        <div class="col-span-4 w-full relative overflow-hidden">
            <div class=" absolute w-4 h-4 rounded-full -top-2 -left-2 bg-white"></div>
            <div class=" absolute w-4 h-4 rounded-full -bottom-2 -left-2 bg-white"></div>
            <div class="p-2 flex flex-col gap-2">
                <div>
                    <p class="text-sm font-bold">Giảm 200,000 đ</p>
                    <p class="text-xs">Đơn hàng từ 3 triệu</p>
                </div>
                <div class="flex justify-between items-center">
                    <p class="text-[10px]">HSD: 30/09/2024</p>
                    <div class="text-xs p-1 bg-blue-500 text-white rounded-md cursor-pointer">Coppy</div>
                </div>
            </div>
        </div> 
    </div>   
</template>

<script>
export default {
    name:"VoucherItem",
    
}
</script>