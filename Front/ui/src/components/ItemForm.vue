<template>
  <h3 class="title">Add items form</h3>
  <div class="columns px-3">
    <div class="field is-one-quarter">
      <label class="label" for="name">Name</label>
      <input class="input" type="text" id="name" v-model="item.name" />
    </div>
    <div class="field is-one-quarter ml-2">
      <label class="label" for="type">Type</label>
      <div class="select">
        <select id="type" v-model="item.type">
          <option value="Basic">Basic</option>
          <option value="Box">Box</option>
          <option value="Document">Document</option>
        </select>
      </div>
    </div>
    <div class="field is-one-quarter ml-2">
      <label class="label" for="expirationDate">Exp. date</label>
      <input
        class="input"
        type="date"
        id="expirationDate"
        v-model="item.expirationDate"
      />
    </div>
    <div class="field is-one-quarter ml-2">
      <label class="label" for="button">&nbsp;</label>
      <button class="button is-one-quarter is-primary" id="button" @click="add">
        <span>Add</span>
        <span class="icon is-small">
          <i class="fas fa-plus"></i>
        </span>
      </button>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { Item } from "@/model/Item";
import { InventoryService } from "@/client/InventoryService";
import { defineEmits, reactive } from "vue";

const emit = defineEmits(["itemAdded", "errorThrown"]);

const item = reactive(new Item("", "Basic", ""));

const apiClient = new InventoryService();

const add = () => {
  apiClient
    .add(item)
    .then(() => emit("itemAdded"))
    .catch((reason) => emit("errorThrown", reason.response.data));
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss"></style>
