<template>
  <div>
    <h1>{{ title }}</h1>
    <p v-html="content"></p>
  </div>
</template>

<script>
export default {
  name: "Blog",
  props: {
    title: String,
    content: String // or any other constructor
  }
};
</script>

<style scoped>
</style>
