<template>
  <div class="edit">
    <form @submit="putBlog">
      <textarea class="form-control" v-model="title"></textarea>
      <textarea class="form-control" v-model="content"></textarea>

      <button class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "blog",
  data() {
    return {
      title: "",
      content: ""
    };
  },
  methods: {
    getBlog() {
      const path = "https://localhost:5001/api/blogs/" + this.$route.params.id;
      axios
        .get(path)
        .then(res => {
          this.title = res.data.title;
          this.content = res.data.content;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    putBlog(e) {
      e.preventDefault();
      const path = "https://localhost:5001/api/blogs/" + this.$route.params.id;
      axios
        .put(path, {
          id: this.$route.params.id,
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
  },
  created() {
    this.getBlog();
  }
};
</script>

<style scoped>
</style>
