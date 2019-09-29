<template>
  <div class="home">
    <div v-for="(blog,index) in blogs" :key="blog.id + '_' + index">
      <router-link :to="'/blog/' + blog.id">
        <article>
          <h2>{{ blog.title }}</h2>
          <p>{{ blog.content.substring(0,300) + "..." }}</p>
        </article>
      </router-link>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "home",
  data() {
    return {
      blogs: []
    };
  },
  methods: {
    getBlogs() {
      const path = "https://localhost:5001/api/blogs";
      axios
        .get(path)
        .then(res => {
          this.blogs = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    }
  },
  created() {
    this.getBlogs();
  }
};
</script>

<style scoped>
</style>
