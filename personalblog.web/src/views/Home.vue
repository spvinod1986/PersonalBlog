<template>
  <div class="home">
    <Blog v-bind:title="blog.title" v-bind:content="blog.content"></Blog>
  </div>
</template>

<script>
// @ is an alias to /src
import Blog from "@/components/Blog.vue";
import axios from "axios";

export default {
  name: "home",
  components: {
    Blog
  },
  data() {
    return {
      blog: []
    };
  },
  methods: {
    getBlog() {
      const path = "https://localhost:5001/api/blogs/5d8d8846f7fe611ad4ad1bf5";
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
