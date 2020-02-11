<template>
  <div class="create">
    <span>
      <time datetime="2019-09-30">30 SEP 2019</time>
    </span>
    <textarea class="form-control title" v-model="title" placeholder="Enter Title here"></textarea>
    <editor @onUpdate="onEditorContentUpdate"></editor>
    <button class="btn btn-success" v-on:click="postBlog">Save</button>
  </div>
</template>

<script>
import axios from "axios";
import editor from "./Editor";
import router from "../router";

export default {
  name: "create",
  components: {
    editor
  },
  data() {
    return {
      title: "",
      content: ""
    };
  },
  methods: {
    async postBlog(e) {
      e.preventDefault();
      const path = process.env.VUE_APP_API_PATH + "blogs";
      const token = await this.$auth.getTokenSilently();
      axios
        .post(
          path,
          {
            title: this.title,
            content: this.content
          },
          {
            headers: {
              Authorization: `Bearer ${token}`
            }
          }
        )
        .then(res => {
          router.push({ name: "edit", params: { id: res.data.id } });
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    onEditorContentUpdate(editorContent) {
      this.content = editorContent;
    }
  }
};
</script>

<style scoped>
.title {
  border: hidden;
  font-size: 2rem;
  font-weight: 600;
  color: #222222;
}
</style>
