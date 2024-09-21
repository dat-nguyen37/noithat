<template>
    <div :class="own ? 'items-end':'items-start'" class="flex flex-col">
        <span class="h-auto px-2 max-w-40 flex-wrap bg-blue-700 rounded-lg text-white">hello</span>
        <p class="text-[10px]">1h ago</p>
    </div>
</template>

<script>
export default {
    name:"MessageText",
    props:['own']
}
</script>