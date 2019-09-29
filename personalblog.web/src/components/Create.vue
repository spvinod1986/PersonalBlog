<template>
  <div class="create">
    <form @submit="postBlog">
      <textarea class="form-control" v-model="title" placeholder="Enter Title"></textarea>
      <textarea class="form-control" v-model="content" placeholder="Enter Content"></textarea>

      <button class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "create",
  data() {
    return {
      title: "",
      content: ""
    };
  },
  methods: {
    postBlog(e) {
      e.preventDefault();
      const path = "https://localhost:5001/api/blogs";
      axios
        .post(path, {
          title: this.title,
          content: this.content
        })
        .then(res => {
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    }
  }
};
</script>

<style scoped>
</style>
