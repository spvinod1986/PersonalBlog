<template>
  <div class="blog">
    <article>
      <h1>{{ blog.title }}</h1>
      <p v-html="blog.content"></p>
    </article>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "blog",
  data() {
    return {
      blog: {}
    };
  },
  methods: {
    getBlog() {
      const path = "https://localhost:5001/api/blogs/" + this.$route.params.id;
      axios
        .get(path)
        .then(res => {
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    }
  },
  created() {
    this.getBlog();
  }
};
</script>

<style scoped>
</style>
