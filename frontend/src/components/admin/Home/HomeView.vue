<template>
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-5 h-full">
        <div class="bg-blue-400 shadow-2xl flex items-center text-center h-32">
            <div class="w-[50%]">{{ 10 |numeral }}</div>
            <div class="w-[50%] ">
                <VueIcon type="mdi" :path="mdiHome" class="text-5xl"/>                                
            </div>
        </div>
        <div class="bg-red-400 shadow-2xl flex items-center text-center h-32">
            <div class="w-[50%]">{{ 10 |numeral }}</div>
            <div class="w-[50%] ">
                <VueIcon type="mdi" :path="mdiHome" class="text-5xl"/>
            </div>
        </div>
        <div class="bg-yellow-400 shadow-2xl flex items-center text-center h-32">
            <div class="w-[50%]">{{ 10 |numeral }}</div>
            <div class="w-[50%] ">
                <VueIcon type="mdi" :path="mdiHome" class="text-5xl"/>
            </div>
        </div>
        <div class="bg-gray-400 shadow-2xl flex items-center text-center h-32">
            <div class="w-[50%]">{{ 1000000 |numeral }}</div>
            <div class="w-[50%] ">
                <VueIcon type="mdi" :path="mdiHome" class="text-5xl"/>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name:"HomeView"
}
</script>