<template>
  <div>
    <p>{{ msg }}</p>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "Blog",
  data() {
    return {
      msg: "Hello!! I am Vinod. This is my blog!!!"
    };
  },
  methods: {}
};
</script>

<style scoped>
</style>
