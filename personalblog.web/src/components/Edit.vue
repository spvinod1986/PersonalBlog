<template>
  <div class="edit">
    <form @submit="putBlog">
      <textarea class="form-control" v-model="title"></textarea>
      <editor v-bind:content="content" @onUpdate="onEditorContentUpdate" :key="id"></editor>
      <button class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import editor from "./Editor";

export default {
  name: "blog",
  components: {
    editor
  },
  data() {
    return {
      id: "",
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
          this.id = res.data.id;
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
    },
    onEditorContentUpdate(editorContent) {
      this.content = editorContent;
    }
  },
  created() {
    this.getBlog();
  }
};
</script>

<style scoped>
</style>
