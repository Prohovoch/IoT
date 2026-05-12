using IoT.DTO.Devices;
using IoT.Service.Device;
using Microsoft.AspNetCore.Mvc;

namespace IoT.Controllers
{
    [ApiController]
    [Route("api/hubs/{hubId:guid}/devices")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            try
            {
                var result = await _deviceService.GetAllAsync();
                return Ok(result);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
        {
            try
            {
                var result = await _deviceService.GetByIdAsync(id, ct);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id:guid}/telemetry")]
        public async Task<IActionResult> GetWithTelemetry(Guid id, CancellationToken ct)
        {
            try
            {
                var result = await _deviceService.GetByIdWithTelemAsync(id, ct);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499,  ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            Guid hubId,
            DeviceRequest request,
            CancellationToken ct)
        {
            try
            {
                await _deviceService.CreateDevice(request, hubId, ct);
                return Ok();
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id,
            DeviceUpdate update,
            CancellationToken ct)
        {
            try
            {
                await _deviceService.UpdateDevice(id, update, ct);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
        {
            try
            {
                await _deviceService.DeleteDevice(id, ct);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                return StatusCode(499, ex.Message);


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}