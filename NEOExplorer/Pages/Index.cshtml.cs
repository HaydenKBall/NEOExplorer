using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NEOExplorer.Data;
using NEOExplorer.Providers;

namespace NEOExplorer.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<NearEarthObject>? NeoData { get; set; }

        [BindProperty]
        public string? BiggerThan { get; set; }

        [BindProperty]
        public string? IsHazardous { get; set; }

        [BindProperty]
        public string? FasterThan { get; set; }

        public void OnGet()
        {
            NeoData = null;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            NeoData = await NeoApiProvider.GetNearEarthObjects();

            if (!string.IsNullOrEmpty(BiggerThan))
            {
                var biggerThan = double.Parse(BiggerThan);

                NeoData = NeoData.Where(x => x.EstimatedDiameter.Feet.EstimatedDiameterMin >= biggerThan).ToList();
            }

            if (!string.IsNullOrEmpty(IsHazardous))
            {
                bool isHazardous = bool.Parse(IsHazardous);

                NeoData = NeoData.Where(x => x.IsPotentiallyHazardousAsteroid == isHazardous).ToList();

            }

            if (!string.IsNullOrEmpty(FasterThan))
            {
                var fasterThan = double.Parse(FasterThan);

                NeoData = NeoData.Where(x => x.RelativeVelocityFromClosestApproachToToday > fasterThan).ToList();
            }

            return Page();
        }
    }
}