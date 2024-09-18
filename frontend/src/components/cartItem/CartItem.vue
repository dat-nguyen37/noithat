<template>
    <tr class="text-sm lg:text-base w-full">
            <td class="flex items-center gap-3 p-3 max-w-[70vh]">
                <img src="/assets/image/New/new1.webp" alt="" class="w-12 h-12 sm:w-16 sm:h-16 object-cover">
                <div class="text-xs md:text-sm">
                    <p class=" font-bold text-gray-600">Hệ tủ bếp MOHO Kitchen Premium Ubeda Nhiều Kích Thước</p>
                    <p class="">1m5 chữ I</p>
                    <p class="hover:text-yellow-500 cursor-pointer hidden lg:block">Xóa</p>
                    <div class="flex lg:hidden">
                        <button class="w-6 h-6 border">-</button>
                        <input type="number" class="w-6 h-6 border"  min="1">
                        <button class="w-6 h-6 border">+</button>   
                    </div>
                </div>
            </td>
            <td class="text-xs md:text-sm text-red-500 font-bold p-2">
                11,890,000 <u>đ</u>
                <p class="text-yellow-500 cursor-pointer lg:hidden">Xóa</p>
            </td>
            <td class="p-2 hidden lg:table-cell">
                <button class="w-6 h-6 border">-</button>
                <input type="number" class="w-6 h-6 border"  min="1">
                <button class="w-6 h-6 border">+</button>
            </td>
            <td class="text-red-500 font-bold p-2 hidden lg:table-cell">11,890,000 <u>đ</u></td>
        </tr>
</template>

<script>
export default {
    name:"CartItem",
}
</script>