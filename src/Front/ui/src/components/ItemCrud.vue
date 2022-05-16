<template>
  <item-form @itemAdded="listChanged" @errorThrown="onError"></item-form>
  <message-box ref="messageBox" :message="errorMessage"></message-box>
  <item-list ref="itemList" @itemRemoved="listChanged"></item-list>
</template>

<script lang="ts" setup>
import ItemForm from "@/components/ItemForm.vue";
import ItemList from "@/components/ItemList.vue";
import MessageBox from "@/components/MessageBox.vue";
import { ref } from "vue";

const itemList = ref<any>();

const messageBox = ref<any>();
const errorMessage = ref("");

const onError = (reason: any) => {
  console.log(reason);
  errorMessage.value = reason;
  messageBox.value.show();
};

const listChanged = () => {
  console.log("item added in form", itemList.value);
  messageBox.value.hide();
  itemList.value.updateItems();
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
