<template>
  <div :style="style">
    <div>{{ props.message }}</div>
    <button @click="hide">Close</button>
  </div>
</template>

<script lang="ts" setup>
import { defineExpose, defineProps, ref } from "vue";
import ResponseData from "@/types/ResponseData";

const props = defineProps({
  message: {
    type: String,
    value: "",
    required: false,
  },
});

const style = ref("display: none;");

const hide = () => {
  style.value = "display: none;";
};

const show = () => {
  style.value = "display: block;";
};

defineExpose({ show, hide });
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
