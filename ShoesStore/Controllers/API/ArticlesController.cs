using ShoesStore.DAL;
using ShoesStore.Filters;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace ShoesStore.Controllers.API
{
    [RoutePrefix("services/articles")]
    [BasicAuthenticationAttribute]
    public class ArticlesController : ApiController
    {
        private StoreContext db = new StoreContext();

        // GET: Articles
        [Route("")]
        public IHttpActionResult GetArticles()
        {

            try
            {
                var articles = db.Articles.ToList<Article>();

                List<ArticleViewModel> list = new List<ArticleViewModel>();
                if (articles != null)
                {
                    foreach (Article article in articles)
                    {
                        var store = article.Store;
                        list.Add(new ArticleViewModel { id = article.Id, name = article.Name, description = article.Description, price = article.Price, total_in_shelf = article.total_in_shelf, total_in_vault = article.total_in_vault, store_name = store.Name });
                    }
                }

                var jsonResponse = new
                {
                    articles = list,
                    success = true,
                    total_elements = list.Count
                };
                return Ok(jsonResponse);
            }
            catch (Exception)
            {
                var jsonResponse = new
                {
                    error_msg = "Server Error",
                    success = false,
                    error_code = 500
                };
                return BadRequest(jsonResponse.ToString());
            }
        }

        // GET: Articles by store
        [Route("stores/{id:int}")]
        public IHttpActionResult GetArticlesByStore(int? id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            try
            {
                if (Regex.IsMatch(id.ToString(), @"^\d$"))
                {
                    var articles = from a in db.Articles
                                   where a.Store.Id == id
                                   select a;
                    var stores = db.Stores.ToList();
                    if (articles.ToList().Count != 0)
                    {
                        List<ArticleViewModel> list = new List<ArticleViewModel>();
                        foreach (Article article in articles)
                        {
                            var store = article.Store;
                            list.Add(new ArticleViewModel { id = article.Id, name = article.Name, description = article.Description, price = article.Price, total_in_shelf = article.total_in_shelf, total_in_vault = article.total_in_vault, store_name = store.Name });
                        }
                        var jsonResponse = new
                        {
                            articles = list,
                            success = true,
                            total_elements = list.Count
                        };
                        return Ok(jsonResponse);
                    }
                    else
                    {
                        var jsonResponse = new
                        {
                            error_msg = "Record not Found",
                            success = false,
                            error_code = 404
                        };
                        return BadRequest(jsonResponse.ToString());
                    }
                }
                else
                {
                    var jsonResponse = new
                    {
                        error_msg = "Bad Request",
                        success = false,
                        error_code = 400
                    };
                    return BadRequest(jsonResponse.ToString());
                }

            }
            catch (Exception)
            {
                var jsonResponse = new
                {
                    error_msg = "Server Error",
                    success = false,
                    error_code = 500
                };
                return BadRequest(jsonResponse.ToString());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}